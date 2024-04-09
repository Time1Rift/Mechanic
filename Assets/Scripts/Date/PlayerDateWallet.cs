using UnityEngine;
#if UNITY_WEBGL && !UNITY_EDITOR
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;
#endif

public class PlayerDateWallet
{
    private const string NameFile = "CountCoins";

    public PlayerDateWallet()
    {
        if (PlayerPrefs.HasKey(NameFile) == false)
            PlayerPrefs.SetInt(NameFile, 0);
    }

    public int GetValue() => PlayerPrefs.GetInt(NameFile);

    public void SetValue(int value)
    {
        PlayerPrefs.SetInt(NameFile, value);
        PlayerPrefs.Save();
    }
}