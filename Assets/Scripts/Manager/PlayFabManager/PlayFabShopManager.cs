using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Assets.Scripts.Common.Data;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using PlayFab;
using PlayFab.ClientModels;
using Repository;
using TMPro;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Purchasing;
using Zenject;

namespace Manager.NetworkManager
{
    public class PlayFabShopManager : IStoreListener, IDisposable
    {
        private bool _isInitialized;
        private ConfigurationBuilder _builder;
        private IStoreController _storeController;
        private IExtensionProvider _extensionProvider;
        private string _itemName;
        private Sprite _coinSprite;
        private Sprite _gemSprite;
        private CancellationTokenSource _cancellationTokenSource;
        [Inject] private PlayFabVirtualCurrencyManager _playFabVirtualCurrencyManager;
        [Inject] private PlayFabUserDataManager _playFabUserDataManager;
        [Inject] private CharacterMasterDataRepository _characterMasterDataRepository;
        [Inject] private UserDataRepository _userDataRepository;
        [Inject] private CatalogDataRepository _catalogDataRepository;
        [Inject] private WeaponMasterDataRepository _weaponMasterDataRepository;
        [Inject] private PopupGenerateUseCase _popupGenerateUseCase;

        public async UniTask InitializePurchasing()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            if (_isInitialized)
            {
                return;
            }

            _isInitialized = true;
            var options = new InitializationOptions();
            await UnityServices.InitializeAsync(options);
            _builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            foreach (var catalogItem in _catalogDataRepository.GetCatalogItems().FindAll(x =>
                         x.ItemClass == GameCommonData.ConsumableClassKey))
            {
                _builder.AddProduct(catalogItem.ItemId, ProductType.Consumable);
            }

            UnityPurchasing.Initialize(this, _builder);

            var coinSprite = await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "coin");
            _coinSprite = (Sprite)coinSprite;
            var gemSprite = await Resources.LoadAsync<Sprite>(GameCommonData.VirtualCurrencySpritePath + "gem");
            _gemSprite = (Sprite)gemSprite;
        }

        public async UniTask TryPurchaseItemByRealMoney(string itemName)
        {
            await Login();
            _itemName = itemName;
            _storeController.InitiatePurchase(itemName);
        }

        public async UniTask<bool> TryPurchaseGacha(string itemName, string virtualCurrencyKey, int price,
            string shopKey, RewardGetView rewardView, TextMeshProUGUI errorText)
        {
            var request = new PurchaseItemRequest()
            {
                ItemId = itemName,
                VirtualCurrency = virtualCurrencyKey,
                Price = price,
                StoreId = shopKey,
            };
            var result = await PlayFabClientAPI.PurchaseItemAsync(request);
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                errorText.text = result.Error.ErrorMessage;
                return false;
            }

            await _playFabVirtualCurrencyManager.SetVirtualCurrency();
            var getItems = result.Result.Items.Where(x => x.BundleParent != null);
            foreach (var item in getItems)
            {
                if (item.ItemClass.Equals(GameCommonData.CharacterClassKey))
                {
                    var index = int.Parse(item.ItemId);
                    var characterData = _characterMasterDataRepository.GetCharacterData(index);
                    rewardView.rewardImage.sprite = characterData.SelfPortraitSprite;
                    var userData = _userDataRepository.AddCharacterData(index);
                    await _playFabUserDataManager.TryUpdateUserDataAsync(userData);
                }

                if (item.ItemClass.Equals(GameCommonData.LoginBonusClassKey))
                {
                    var loginBonusItemData = _catalogDataRepository.GetAddVirtualCurrencyItemData(item.ItemId);
                    if (loginBonusItemData == null)
                    {
                        return false;
                    }

                    if (loginBonusItemData.vc == GameCommonData.CoinKey)
                    {
                        rewardView.rewardImage.sprite = _coinSprite;
                        rewardView.rewardText.text = loginBonusItemData.price.ToString("D");
                    }

                    if (loginBonusItemData.vc == GameCommonData.GemKey)
                    {
                        rewardView.rewardImage.sprite = _gemSprite;
                        rewardView.rewardText.text = loginBonusItemData.price.ToString("D");
                    }

                    await _playFabVirtualCurrencyManager.SetVirtualCurrency();
                }
            }

            return true;
        }


        public async UniTask<bool> TryPurchaseCharacter(int characterId, string virtualCurrencyKey, int price)
        {
            var request = new PurchaseItemRequest
            {
                ItemId = characterId.ToString(),
                VirtualCurrency = virtualCurrencyKey,
                Price = price,
            };
            var result = await PlayFabClientAPI.PurchaseItemAsync(request);
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                return false;
            }

            await _playFabVirtualCurrencyManager.SetVirtualCurrency();
            var userData = _userDataRepository.AddCharacterData(characterId);
            var result2 = await _playFabUserDataManager.TryUpdateUserDataAsync(userData);
            return result2;
        }

        public async UniTask<bool> TryPurchaseRandomCharacters(int createCount)
        {
            var characterMasterDatum = _characterMasterDataRepository.GetAllCharacterData().ToArray();
            for (var i = 0; i < createCount; i++)
            {
                var characterId = characterMasterDatum[UnityEngine.Random.Range(0, characterMasterDatum.Length)].Id;
                _userDataRepository.AddCharacterData(characterId);
            }

            await _playFabVirtualCurrencyManager.SetVirtualCurrency();
            var result2 = await _playFabUserDataManager.TryUpdateUserDataAsync();
            return result2;
        }

        public async UniTask<bool> TryPurchaseLevelUpItem(int level, string virtualCurrencyKey, int price,
            int characterId, PurchaseErrorView purchaseErrorView)
        {
            var request = new PurchaseItemRequest
            {
                ItemId = GameCommonData.LevelItemKey + level,
                VirtualCurrency = virtualCurrencyKey,
                Price = price,
            };
            var result = await PlayFabClientAPI.PurchaseItemAsync(request);
            if (result.Error != null)
            {
                purchaseErrorView.errorInfoText.text = result.Error.ErrorMessage;
                Debug.LogError(result.Error.GenerateErrorReport());
                return false;
            }

            var result2 = _userDataRepository.UpgradeCharacterLevel(characterId, level);
            return result2;
        }

        public async UniTask<bool> TryPurchaseLoginBonusItem(int day, string virtualCurrencyKey, int price,
            RewardGetView rewardView, TextMeshProUGUI errorText)
        {
            var request = new PurchaseItemRequest
            {
                ItemId = GameCommonData.LoginBonusItemKey + day,
                VirtualCurrency = virtualCurrencyKey,
                Price = price,
            };
            var result = await PlayFabClientAPI.PurchaseItemAsync(request);
            if (result.Error != null)
            {
                errorText.text = result.Error.ErrorMessage;
                Debug.Log(result.Error.GenerateErrorReport());
                return false;
            }

            foreach (var item in result.Result.Items)
            {
                if (!item.ItemClass.Equals(GameCommonData.LoginBonusClassKey)) continue;
                var itemName = item.ItemId;
                var loginBonusItemData = _catalogDataRepository.GetAddVirtualCurrencyItemData(itemName);
                if (loginBonusItemData == null)
                {
                    return false;
                }

                if (loginBonusItemData.vc == GameCommonData.CoinKey)
                {
                    rewardView.rewardImage.sprite = _coinSprite;
                    rewardView.rewardText.text = loginBonusItemData.price.ToString("D");
                }

                if (loginBonusItemData.vc == GameCommonData.GemKey)
                {
                    rewardView.rewardImage.sprite = _gemSprite;
                    rewardView.rewardText.text = loginBonusItemData.price.ToString("D");
                }
            }

            await _playFabVirtualCurrencyManager.SetVirtualCurrency();
            return true;
        }

        public async UniTask<bool> TryPurchaseItem
        (
            string itemId,
            string virtualCurrencyKey,
            int price,
            TextMeshProUGUI errorText
        )
        {
            var request = new PurchaseItemRequest
            {
                ItemId = itemId,
                VirtualCurrency = virtualCurrencyKey,
                Price = price,
            };
            var result = await PlayFabClientAPI.PurchaseItemAsync(request);
            if (result.Error != null)
            {
                if (errorText != null)
                {
                    errorText.text = result.Error.ErrorMessage;
                }

                Debug.LogError(result.Error.GenerateErrorReport());
                return false;
            }

            await _playFabVirtualCurrencyManager.SetVirtualCurrency();
            return true;
        }


        private async UniTask Login()
        {
#if UNITY_IOS
        var request = new LoginWithIOSDeviceIDRequest()
        {
            CreateAccount = true,
            DeviceId = SystemInfo.deviceUniqueIdentifier
        };

        var result = await PlayFabClientAPI.LoginWithIOSDeviceIDAsync(request);

        if (result.Error != null)
        {
            Debug.LogError(result.Error.GenerateErrorReport());
        }
        else
        {
            Debug.Log("Logged in");

            // Refresh available items
            RefreshIAPItems();
        }
#elif UNITY_ANDROID
            var request = new LoginWithAndroidDeviceIDRequest()
            {
                CreateAccount = true,
                AndroidDeviceId = SystemInfo.deviceUniqueIdentifier
            };
            var result = await PlayFabClientAPI.LoginWithAndroidDeviceIDAsync(request);

            if (result.Error != null)
            {
                Debug.LogError(result.Error.GenerateErrorReport());
            }
#endif
        }

        private async void ValidateGooglePlayPurchaseAsync(PurchaseEventArgs e)
        {
            Debug.Log(e.purchasedProduct.metadata.isoCurrencyCode);
            var googleReceipt = GooglePurchase.FromJson(e.purchasedProduct.receipt);
            var request = new ValidateGooglePlayPurchaseRequest
            {
                CurrencyCode = e.purchasedProduct.metadata.isoCurrencyCode,
                PurchasePrice = (uint)(e.purchasedProduct.metadata.localizedPrice * 100),
                ReceiptJson = googleReceipt.PayloadData.json,
                Signature = googleReceipt.PayloadData.signature
            };

            var result = await PlayFabClientAPI.ValidateGooglePlayPurchaseAsync(request);

            if (result.Error != null)
            {
                Debug.Log("Validated failed" + result.Error.GenerateErrorReport());
                return;
            }

            var itemData = _catalogDataRepository.GetAddVirtualCurrencyItemDatum()
                .FirstOrDefault(x => x.Name == _itemName);
            if (itemData == null)
            {
                return;
            }

            await _playFabVirtualCurrencyManager.AddVirtualCurrency(itemData.vc, itemData.price);
            Debug.Log("Validated success");
        }


        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            throw new NotImplementedException();
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            throw new NotImplementedException();
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            if (!_isInitialized)
            {
                return PurchaseProcessingResult.Complete;
            }

            Debug.Log("手続き開始");
            // Test edge case where product is unknown
            if (purchaseEvent.purchasedProduct == null)
            {
                Debug.LogWarning("Attempted to process purchase with unknown product. Ignoring");
                return PurchaseProcessingResult.Complete;
            }

            // Test edge case where purchase has no receipt
            if (string.IsNullOrEmpty(purchaseEvent.purchasedProduct.receipt))
            {
                Debug.LogWarning("Attempted to process purchase with no receipt: ignoring");
                return PurchaseProcessingResult.Complete;
            }

            ValidateGooglePlayPurchaseAsync(purchaseEvent);
            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _storeController = controller;
            _extensionProvider = extensions;
        }

        public async UniTask<(bool, IReadOnlyList<int>)> AddRandomWeaponAsync(int createCount, int cost)
        {
            var weaponMasterDatum = _weaponMasterDataRepository.GetAllWeaponData().ToArray();
            var result = new List<int>();

            /*for (var i = 0; i < createCount; i++)
            {
                var weaponId = weaponMasterDatum[UnityEngine.Random.Range(0, weaponMasterDatum.Length)].Id;
                _userDataRepository.AddWeaponData(weaponId);
                result.Add(weaponId);
            }*/
            //todo: 1回の購入で全ての武器を購入できるようにする
            foreach (var masterData in weaponMasterDatum)
            {
                _userDataRepository.AddWeaponData(masterData.Id);
                result.Add(masterData.Id);
            }

            await _playFabUserDataManager.TryUpdateUserDataAsync();
            await _playFabVirtualCurrencyManager.SubtractVirtualCurrency(GameCommonData.GemKey, cost);
            return (false, result);
        }

        public async UniTask<(bool, string, int)> SellWeaponAsync(int weaponId, int sellAmount)
        {
            var userData = _userDataRepository.GetUserData();
            var possessedWeaponDatum = _userDataRepository.GetAllPossessedWeaponDatum();
            var weaponMasterDatum = _weaponMasterDataRepository.GetAllWeaponData().ToArray();
            var weaponData = weaponMasterDatum.FirstOrDefault(x => x.Id == weaponId);
            if (weaponData == null)
            {
                var candidate = possessedWeaponDatum
                    .OrderBy(weapon => weapon.Key.WeaponType)
                    .ThenBy(weapon => weapon.Key.Rare)
                    .ThenBy(weapon => weapon.Key.Id)
                    .First();
                return (false, GameCommonData.Terms.InvalidData, candidate.Key.Id);
            }

            if (!userData.PossessedWeapons.ContainsKey(weaponId))
            {
                var candidate = possessedWeaponDatum
                    .OrderBy(weapon => weapon.Key.WeaponType)
                    .ThenBy(weapon => weapon.Key.Rare)
                    .ThenBy(weapon => weapon.Key.Id)
                    .First();
                return (false, GameCommonData.Terms.NorHaveWeapon, candidate.Key.Id);
            }

            var totalPrice = GameCommonData.GetWeaponSellPrice(weaponData.Rare) * sellAmount;
            var addVirtualCurrencyResponse = await _playFabVirtualCurrencyManager.AddVirtualCurrency(GameCommonData.CoinKey, totalPrice);
            if (!addVirtualCurrencyResponse)
            {
                return (false, GameCommonData.Terms.ErrorAddVirtualCurrency, weaponId);
            }

            _userDataRepository.SubtractWeaponData(weaponId, sellAmount);
            var userUpdateResponse = await _playFabUserDataManager.TryUpdateUserDataAsync();
            if (!userUpdateResponse)
            {
                return (false, GameCommonData.Terms.ErrorUpdateUserData, weaponId);
            }

            return (true, "", weaponId);
        }
    }

    public class JsonData
    {
        // JSON Fields, ! Case-sensitive
        public string orderId;
        public string packageName;
        public string productId;
        public long purchaseTime;
        public int purchaseState;
        public string purchaseToken;
    }

    public class PayloadData
    {
        public JsonData JsonData;

        // JSON Fields, ! Case-sensitive
        public string signature;
        public string json;

        public static PayloadData FromJson(string json)
        {
            Debug.Log(json);
            var payload = JsonUtility.FromJson<PayloadData>(json);
            payload.JsonData = JsonUtility.FromJson<JsonData>(payload.json);
            return payload;
        }
    }

    public class GooglePurchase
    {
        public PayloadData PayloadData;

        // JSON Fields, ! Case-sensitive
        public string Store;
        public string TransactionID;
        public string Payload;

        public static GooglePurchase FromJson(string json)
        {
            Debug.Log(json);
            var purchase = JsonUtility.FromJson<GooglePurchase>(json);
            purchase.PayloadData = PayloadData.FromJson(purchase.Payload);
            return purchase;
        }
    }
}