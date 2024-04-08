using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct InfoLeaderboard
{
    [field: SerializeField] public GameObject LeaderboardScreen { get; private set; }
    [field: SerializeField] public Button ButtonLeaderboard { get; private set; }
    [field: SerializeField] public Button ButtonClose { get; private set; }
    [field: SerializeField] public YandexLeaderboard YandexLeaderboard { get; private set; }
    [field: SerializeField] public AudioSource AudioSource { get; private set; }
}