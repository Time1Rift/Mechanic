using UnityEngine;

public class PlayerDateCompletedLevels
{
    private const string NameFile = "CompletedLevels";

    public PlayerDateCompletedLevels()
    {
        if (PlayerPrefs.HasKey(NameFile) == false)
            PlayerPrefs.SetInt(NameFile, 0);
    }

    public int GetValue() => PlayerPrefs.GetInt(NameFile);

    public void SetValue(int value) => PlayerPrefs.SetInt(NameFile, value);

    public void AddValue() => PlayerPrefs.SetInt(NameFile, (GetValue() + 1));
}