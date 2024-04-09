using UnityEngine;
#if UNITY_WEBGL && !UNITY_EDITOR
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;
#endif

public class PlayerDateCompletedLevels
{
    private const string NameFile = "CompletedLevels";

    public PlayerDateCompletedLevels()
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

    public void AddValue() => SetValue((GetValue() + 1));
}