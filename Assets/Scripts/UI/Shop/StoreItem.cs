using TMPro;

public class StoreItem
{
    private TextMeshProUGUI _priceClearShelfText;
    
    public StoreItem(StoreItemInfo shopInfo, TextMeshProUGUI priceClearShelfText)
    {
        PriceClearShelf = shopInfo.PriceClearShelf;
        _priceClearShelfText = priceClearShelfText;

        _priceClearShelfText.text = PriceClearShelf.ToString();
    }

    public int PriceClearShelf { get; private set; }

    public bool TryPay(int CountCoins) => PriceClearShelf <= CountCoins;
}