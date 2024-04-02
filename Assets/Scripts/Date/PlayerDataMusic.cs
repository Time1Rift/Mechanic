using UnityEngine;

public class PlayerDataMusic
{
    private const string NameFile = "isBoolAudio";

    public PlayerDataMusic()
    {
        if (PlayerPrefs.HasKey(NameFile) == false)
            PlayerPrefs.SetInt(NameFile, 1);
    }

    public bool GetValue() => PlayerPrefs.GetInt(NameFile) == 1 ? true : false;

    public void SetValue(bool value) => PlayerPrefs.SetInt(NameFile, (value == true ? 1 : 0));
}