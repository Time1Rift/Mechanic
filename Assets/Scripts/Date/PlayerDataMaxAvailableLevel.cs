using UnityEngine;
#if UNITY_WEBGL && !UNITY_EDITOR
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;
#endif

public class PlayerDataMaxAvailableLevel
{
    private const string NameFile = "MaxAvailableLevel";

    public PlayerDataMaxAvailableLevel()
    {
        if (PlayerPrefs.HasKey(NameFile) == false)
            PlayerPrefs.SetInt(NameFile, 1);
    }

    public int GetValue() => PlayerPrefs.GetInt(NameFile);

    public void NextValue()
    {
        PlayerPrefs.SetInt(NameFile, (GetValue() + 1));
        PlayerPrefs.Save();
    }
}