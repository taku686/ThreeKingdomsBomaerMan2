using System;
using System.Linq;
using Assets.Scripts.Common.Data;
using Common.Data;
using Cysharp.Threading.Tasks;
using Manager.DataManager;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
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

        //  [Inject] private PlayFabCatalogManager _playFabCatalogManager;
        [Inject] private PlayFabInventoryManager _playFabInventoryManager;
        [Inject] private PlayFabUserDataManager _playFabUserDataManager;
        [Inject] private CharacterDataManager _characterDataManager;
        [Inject] private UserDataManager _userDataManager;
        [Inject] private CatalogDataManager _catalogDataManager;

        //todo 後で消す
        public TextMeshProUGUI DebugText;

        public async UniTask InitializePurchasing()
        {
            if (_isInitialized)
            {
                return;
            }

            var options = new InitializationOptions();
            await UnityServices.InitializeAsync(options);
            _isInitialized = true;
            _builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            foreach (var catalogItem in _catalogDataManager.GetCatalogItems().FindAll(x =>
                         x.ItemClass == GameCommonData.ConsumableClassKey))
            {
                _builder.AddProduct(catalogItem.ItemId, ProductType.Consumable);
            }

            UnityPurchasing.Initialize(this, _builder);
        }

        public void TryPurchaseItem(string itemName)
        {
            _itemName = itemName;
            _storeController.InitiatePurchase(itemName);
        }

        public async UniTask<bool> TryPurchaseGacha(string itemName, string virtualCurrencyKey, int price,
            string shopKey, Image rewardImage, TextMeshProUGUI errorText)
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

            await _playFabInventoryManager.SetVirtualCurrency();
            await UpdateUserData(result, rewardImage);
            return true;
        }


        public async UniTask<bool> TryPurchaseCharacter(string itemName, string virtualCurrencyKey, int price)
        {
            var request = new PurchaseItemRequest()
            {
                ItemId = itemName,
                VirtualCurrency = virtualCurrencyKey,
                Price = price,
            };
            var result = await PlayFabClientAPI.PurchaseItemAsync(request);
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                return false;
            }

            await _playFabInventoryManager.SetVirtualCurrency();
            return true;
        }

        private async UniTask UpdateUserData(PlayFabResult<PurchaseItemResult> result, Image rewardImage)
        {
            var user = _userDataManager.GetUserData();
            var getItems = result.Result.Items.Where(x => x.BundleParent != null);
            foreach (var item in getItems)
            {
                if (item.ItemClass.Equals(GameCommonData.CharacterClassKey))
                {
                    Debug.Log(item.ItemId);
                    var index = int.Parse(item.ItemId);
                    var characterData = _characterDataManager.GetCharacterData(index);
                    rewardImage.sprite = characterData.SelfPortraitSprite;
                    if (user.Characters.Contains(index))
                    {
                        continue;
                    }

                    user.Characters.Add(characterData.ID);
                }
            }

            _userDataManager.SetUserData(user);
            await _playFabUserDataManager.TryUpdateUserDataAsync(GameCommonData.UserKey, user);
        }

        private async UniTask<bool> AddVirtualCurrency(string virtualCurrencyKey, int amount)
        {
            var request = new AddUserVirtualCurrencyRequest()
            {
                Amount = amount,
                VirtualCurrency = virtualCurrencyKey
            };
            var result = await PlayFabClientAPI.AddUserVirtualCurrencyAsync(request);

            if (result.Error != null)
            {
                DebugText.text = "仮想通貨追加失敗";
                return false;
            }

            DebugText.text = "仮想通貨追加";
            await _playFabInventoryManager.SetVirtualCurrency();
            return true;
        }

        private string ItemKeyToVirtualCurrencyKey(string itemKey)
        {
            switch (itemKey)
            {
                case GameCommonData.ThousandCoinItemKey:
                    return GameCommonData.CoinKey;
                case GameCommonData.FiveThousandCoinItemKey:
                    return GameCommonData.CoinKey;
                case GameCommonData.TwelveThousandCoinItemKey:
                    return GameCommonData.CoinKey;
                case GameCommonData.TwentyGemItemKey:
                    return GameCommonData.GemKey;
                case GameCommonData.HundredGemKey:
                    return GameCommonData.GemKey;
                case GameCommonData.TwoHundredGemKey:
                    return GameCommonData.GemKey;
                default:
                    return null;
            }
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
            var request = new ValidateGooglePlayPurchaseRequest()
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

            var itemData = _catalogDataManager.GetAddVirtualCurrencyItemDatum()
                .FirstOrDefault(x => x.Name == _itemName);
            if (itemData == null)
            {
                return;
            }

            await AddVirtualCurrency(itemData.vc, itemData.price);
            Debug.Log("Validated success");
        }


        public void Dispose()
        {
        }

        public void OnInitializeFailed(InitializationFailureReason error)
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