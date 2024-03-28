using UnityEngine;

public class PlayerDataSelectedLevel
{
    private const string SelectedLevel = "SelectedLevel";

    public int Level
    {
        get => PlayerPrefs.HasKey(SelectedLevel) ? PlayerPrefs.GetInt(SelectedLevel) : 1;
        set => PlayerPrefs.SetInt(SelectedLevel, value);
    }

    public void ResetLevel() => PlayerPrefs.SetInt(SelectedLevel, 1);
}