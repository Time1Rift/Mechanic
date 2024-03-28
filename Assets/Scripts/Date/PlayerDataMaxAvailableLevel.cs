using UnityEngine;

public class PlayerDataMaxAvailableLevel
{
    private const string MaxAvailableLevel = "MaxAvailableLevel";

    public int Level
    {
        get => PlayerPrefs.HasKey(MaxAvailableLevel) ? PlayerPrefs.GetInt(MaxAvailableLevel) : 1;
        set => PlayerPrefs.SetInt(MaxAvailableLevel, value);
    }
}
