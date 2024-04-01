using UnityEngine;

public class PlayerDataSelectedLevel
{
    private const string SelectedLevel = "SelectedLevel";

    public PlayerDataSelectedLevel()
    {
        if (PlayerPrefs.HasKey(SelectedLevel) == false)
            PlayerPrefs.SetInt(SelectedLevel, 1);
    }

    public int GetValue() => PlayerPrefs.GetInt(SelectedLevel);

    public void SetValue(int value) => PlayerPrefs.SetInt(SelectedLevel, value);

    public void NextValue() => PlayerPrefs.SetInt(SelectedLevel, (GetValue() + 1));

    public void ResetLevel() => PlayerPrefs.SetInt(SelectedLevel, 1);
}