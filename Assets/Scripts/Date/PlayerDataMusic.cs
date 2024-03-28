using System;
using UnityEngine;

public class PlayerDataMusic
{
    private const string IsBoolAudio = "isBoolAudio";

    public bool IsEnabledMusic
    {
        get => PlayerPrefs.HasKey(IsBoolAudio) ? Convert.ToBoolean(PlayerPrefs.GetInt(IsBoolAudio)) : true;
        set => PlayerPrefs.SetInt(IsBoolAudio, Convert.ToInt32(value));
    }
}