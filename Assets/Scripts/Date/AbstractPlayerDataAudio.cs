using UnityEngine;
#if UNITY_WEBGL && !UNITY_EDITOR
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;
#endif

public abstract class AbstractPlayerDataAudio
{
    private readonly string NameFile = "isBoolAudio";

    public AbstractPlayerDataAudio()
    {
        NameFile = ChangeNameFile();

        if (PlayerPrefs.HasKey(NameFile) == false)
            PlayerPrefs.SetInt(NameFile, 1);
    }

    public bool GetValue() => PlayerPrefs.GetInt(NameFile) == 1 ? true : false;

    public void SetValue(bool value)
    {
        PlayerPrefs.SetInt(NameFile, (value == true ? 1 : 0));
        PlayerPrefs.Save();
    }

    protected abstract string ChangeNameFile();
}