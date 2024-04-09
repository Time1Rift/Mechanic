using UnityEngine;
#if UNITY_WEBGL && !UNITY_EDITOR
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;
#endif

public class PlayerDataSelectedLevel
{
    private const string NameFile = "SelectedLevel";

    public PlayerDataSelectedLevel()
    {
        if (PlayerPrefs.HasKey(NameFile) == false)
            PlayerPrefs.SetInt(NameFile, 1);
    }

    public int GetValue() => PlayerPrefs.GetInt(NameFile);

    public void SetValue(int value)
    {
        PlayerPrefs.SetInt(NameFile, value);
        PlayerPrefs.Save();
    }

    public void NextValue() => SetValue((GetValue() + 1));

    public void ResetLevel() => SetValue(1);
}