using System;
using Assets.Scripts.Common.ResourceManager;
using Common.Data;
using Cysharp.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
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
        [Inject] private PlayFabCatalogManager _playFabCatalogManager;

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
            foreach (var catalogItem in _playFabCatalogManager.CatalogItemList.FindAll(x =>
                         x.ItemClass == GameSettingData.ConsumableKey))
            {
                _builder.AddProduct(catalogItem.ItemId, ProductType.Consumable);
            }

            UnityPurchasing.Initialize(this, _builder);
        }

        public async UniTask<bool> TryPurchaseItem(string itemName, string virtualCurrencyKey, int price)
        {
            await Login();
            var request = new PurchaseItemRequest()
            {
                ItemId = itemName,
                VirtualCurrency = virtualCurrencyKey,
                Price = price,
                StoreId = "MainShop",
                CatalogVersion = "main"
            };
            var result = await PlayFabClientAPI.PurchaseItemAsync(request);
            _storeController.InitiatePurchase(itemName);
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                return false;
            }

            return true;
        }

        public async UniTask<bool> TryPurchaseCharacter(string itemName, string virtualCurrencyKey, int price)
        {
            //  await Login();
            var request = new PurchaseItemRequest()
            {
                ItemId = itemName,
                VirtualCurrency = virtualCurrencyKey,
                Price = price,
            };
            var result = await PlayFabClientAPI.PurchaseItemAsync(request);
            // _storeController.InitiatePurchase(itemName);
            if (result.Error != null)
            {
                Debug.Log(result.Error.GenerateErrorReport());
                return false;
            }

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

        public void BuyItemInGooglePlayStore(string itemId)
        {
            if (!_isInitialized)
            {
                return;
            }

            /*var product = _storeController.products.WithID(itemId);
            Debug.Log(product.definition.id);*/
            _storeController.InitiatePurchase(itemId);
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
            }

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