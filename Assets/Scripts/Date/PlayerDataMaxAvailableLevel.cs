using UnityEngine;

public class PlayerDataMaxAvailableLevel
{
    private const string NameFile = "MaxAvailableLevel";

    public PlayerDataMaxAvailableLevel()
    {
        if (PlayerPrefs.HasKey(NameFile) == false)
            PlayerPrefs.SetInt(NameFile, 1);
    }

    public int GetValue() => PlayerPrefs.GetInt(NameFile);

    public void NextValue() => PlayerPrefs.SetInt(NameFile, (GetValue() + 1));
}
