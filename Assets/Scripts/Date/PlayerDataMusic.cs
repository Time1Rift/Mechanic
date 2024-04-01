using UnityEngine;

public class PlayerDataMusic
{
    private const string IsBoolAudio = "isBoolAudio";

    public PlayerDataMusic()
    {
        if (PlayerPrefs.HasKey(IsBoolAudio) == false)
            PlayerPrefs.SetInt(IsBoolAudio, 1);
    }

    public bool GetValue() => PlayerPrefs.GetInt(IsBoolAudio) == 1 ? true : false;

    public void SetValue(bool value) => PlayerPrefs.SetInt(IsBoolAudio, (value == true ? 1 : 0));
}