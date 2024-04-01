using UnityEngine;

public class PlayerDataMaxAvailableLevel
{
    private const string MaxAvailableLevel = "MaxAvailableLevel";

    public PlayerDataMaxAvailableLevel()
    {
        if (PlayerPrefs.HasKey(MaxAvailableLevel) == false)
            PlayerPrefs.SetInt(MaxAvailableLevel, 1);
    }

    public int GetValue() => PlayerPrefs.GetInt(MaxAvailableLevel);

    public void NextValue() => PlayerPrefs.SetInt(MaxAvailableLevel, (GetValue() + 1));
}
