using TMPro;

public class Wallet
{
    private TextMeshProUGUI _countCoinsText;
    private PlayerDateWallet _playerData;

    public Wallet(TextMeshProUGUI countCoinsText)
    {
        _countCoinsText = countCoinsText;
        _playerData = new PlayerDateWallet();

        CountCoins = _playerData.GetValue();
        _countCoinsText.text = CountCoins.ToString();
    }

    public int CountCoins { get; private set; }

    public void AddCoins(int reward)
    {
        CountCoins += reward;
        UpdateCoinsText();
    }

    public void RemoveCoins(int price)
    {
        CountCoins -= price;
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        _countCoinsText.text = CountCoins.ToString();
        _playerData.SetValue(CountCoins);
    }
}