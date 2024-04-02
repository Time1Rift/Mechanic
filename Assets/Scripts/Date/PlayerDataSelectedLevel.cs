using UnityEngine;

public class PlayerDataSelectedLevel
{
    private const string NameFile = "SelectedLevel";

    public PlayerDataSelectedLevel()
    {
        if (PlayerPrefs.HasKey(NameFile) == false)
            PlayerPrefs.SetInt(NameFile, 1);
    }

    public int GetValue() => PlayerPrefs.GetInt(NameFile);

    public void SetValue(int value) => PlayerPrefs.SetInt(NameFile, value);

    public void NextValue() => PlayerPrefs.SetInt(NameFile, (GetValue() + 1));

    public void ResetLevel() => PlayerPrefs.SetInt(NameFile, 1);
}