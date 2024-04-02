using UnityEngine;

public class PlayerDateWallet
{
    private const string NameFile = "CountCoins";

    public PlayerDateWallet()
    {
        if (PlayerPrefs.HasKey(NameFile) == false)
            PlayerPrefs.SetInt(NameFile, 0);
    }

    public int GetValue() => PlayerPrefs.GetInt(NameFile);

    public void SetValue(int value) => PlayerPrefs.SetInt(NameFile, value);
}