using System;
using Common.Data;
using Manager.NetworkManager;
using UniRx;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class PlayStoreShopManager : IDetailedStoreListener
{
    private readonly PlayFabVirtualCurrencyManager _playFabVirtualCurrencyManager;
    private IStoreController _storeController;
    private IExtensionProvider _extensionProvider;
    private readonly Subject<(string, int, GameCommonData.RewardType, string)> _onSuccessPurchase = new();
    private readonly Subject<string> _onFailedPurchase = new();


    public IObservable<(string, int, GameCommonData.RewardType, string)> _OnSuccessPurchase => _onSuccessPurchase;
    public IObservable<string> _OnFailedPurchase => _onFailedPurchase;

    public void Initialize()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // プロダクトの追加
        builder.AddProduct(GameCommonData.Item1000CoinKey, ProductType.Consumable);
        builder.AddProduct(GameCommonData.Item5000CoinKey, ProductType.Consumable);
        builder.AddProduct(GameCommonData.Item12000CoinKey, ProductType.Consumable);
        builder.AddProduct(GameCommonData.Item20GemKey, ProductType.Consumable);
        builder.AddProduct(GameCommonData.Item100GemKey, ProductType.Consumable);
        builder.AddProduct(GameCommonData.Item200GemKey, ProductType.Consumable);
        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return _storeController != null && _extensionProvider != null;
    }

    public void BuyItem(string itemId)
    {
        var failedReason = "";
        if (IsInitialized())
        {
            var product = _storeController.products.WithID(itemId);

            if (product is { availableToPurchase: true })
            {
                _storeController.InitiatePurchase(product);
            }
            else
            {
                failedReason = "BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase";
                _onFailedPurchase.OnNext(failedReason);
            }
        }
        else
        {
            failedReason = "BuyProductID: FAIL. Not initialized.";
            _onFailedPurchase.OnNext(failedReason);
        }
    }

    // IStoreListenerの実装
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        _storeController = controller;
        _extensionProvider = extensions;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        var failedReason = $"OnPurchaseFailed: FAIL. Product: {product.definition.storeSpecificId}, PurchaseFailureDescription: {failureDescription.message}";
        _onFailedPurchase.OnNext(failedReason);
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        var message = error switch
        {
            InitializationFailureReason.AppNotKnown => "App not known",
            InitializationFailureReason.PurchasingUnavailable => "Purchasing unavailable",
            InitializationFailureReason.NoProductsAvailable => "No products available",
            _ => "Unknown error"
        };
        _onFailedPurchase.OnNext($"OnInitializeFailed: FAIL. InitializationFailureReason: {error}, Message: {message}");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        _onFailedPurchase.OnNext($"OnInitializeFailed: FAIL. InitializationFailureReason: {error}, Message: {message}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        // 購入されたプロダクトIDを取得
        var purchasedProductId = args.purchasedProduct.definition.id;
        Debug.Log($"ProcessPurchase: PASS. Product: {purchasedProductId}");
        switch (purchasedProductId)
        {
            case GameCommonData.Item1000CoinKey:
                _onSuccessPurchase.OnNext((GameCommonData.CoinKey, 1000, GameCommonData.RewardType.Coin, GameCommonData.Item1000CoinKey));
                break;
            case GameCommonData.Item5000CoinKey:
                _onSuccessPurchase.OnNext((GameCommonData.CoinKey, 5000, GameCommonData.RewardType.Coin, GameCommonData.Item5000CoinKey));
                break;
            case GameCommonData.Item12000CoinKey:
                _onSuccessPurchase.OnNext((GameCommonData.CoinKey, 12000, GameCommonData.RewardType.Coin, GameCommonData.Item12000CoinKey));
                break;
            case GameCommonData.Item20GemKey:
                _onSuccessPurchase.OnNext((GameCommonData.GemKey, 20, GameCommonData.RewardType.Gem, GameCommonData.Item20GemKey));
                break;
            case GameCommonData.Item100GemKey:
                _onSuccessPurchase.OnNext((GameCommonData.GemKey, 100, GameCommonData.RewardType.Gem, GameCommonData.Item100GemKey));
                break;
            case GameCommonData.Item200GemKey:
                _onSuccessPurchase.OnNext((GameCommonData.GemKey, 200, GameCommonData.RewardType.Gem, GameCommonData.Item200GemKey));
                break;
        }

        // 購入処理が完了したことを通知
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        var failedReason = $"OnPurchaseFailed: FAIL. Product: {product.definition.storeSpecificId}, PurchaseFailureReason: {failureReason}";
        _onFailedPurchase.OnNext(failedReason);
    }
}