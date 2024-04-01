using UnityEngine;

public class PlayerDateWallet
{
    private const string CountCoins = "CountCoins";

    public PlayerDateWallet()
    {
        if (PlayerPrefs.HasKey(CountCoins) == false)
            PlayerPrefs.SetInt(CountCoins, 0);
    }

    public int GetValue() => PlayerPrefs.GetInt(CountCoins);

    public void SetValue(int value) => PlayerPrefs.SetInt(CountCoins, value);
}