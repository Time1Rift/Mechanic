using TMPro;
using UnityEngine;

public class CompositeRootCoins : MonoBehaviour
{
    [SerializeField] private RewardRange _rewardRange;
    [SerializeField] private StoreItemInfo _storeItemInfo;
    [SerializeField] private TextMeshProUGUI _walletText;
    [SerializeField] private TextMeshProUGUI _priceClearShelfText;
    [SerializeField] private CompositeRootGameplayUI _purchaseButton;

    private Wallet _wallet;
    private StoreItem _storeItem;

    public void Initialize()
    {
        _wallet = new Wallet(_walletText);
        _storeItem = new StoreItem(_storeItemInfo, _priceClearShelfText);
    }

    public void Enable()
    {
        _purchaseButton.Pay().TriedPay += OnTriedPay;
    }

    public void Disable()
    {
        _purchaseButton.Pay().TriedPay -= OnTriedPay;
    }

    public void AddCoins() => _wallet.AddCoins(Random.Range(_rewardRange.MinAddCoins, _rewardRange.MaxAddCoins));

    private void OnTriedPay(IButtonCleaningShelfCoins button)
    {
        if (_storeItem.TryPay(_wallet.CountCoins))
        {
            _wallet.RemoveCoins(_storeItem.PriceClearShelf);
            button.ClearShelf();
        }
    }
}