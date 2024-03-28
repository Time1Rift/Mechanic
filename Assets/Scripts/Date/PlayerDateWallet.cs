using UnityEngine;

public class PlayerDateWallet
{
    private const string CountCoins = "CountCoins";

    public int Wallet
    {
        get => PlayerPrefs.HasKey(CountCoins) ? PlayerPrefs.GetInt(CountCoins) : 0;
        set => PlayerPrefs.SetInt(CountCoins, value);
    }
}