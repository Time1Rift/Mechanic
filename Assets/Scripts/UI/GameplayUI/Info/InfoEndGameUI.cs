using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct InfoEndGameUI
{
    [field: SerializeField] public GameObject VictoryScreen { get; private set; }
    [field: SerializeField] public GameObject GameOverScreen { get; private set; }

    [field: SerializeField] public Button ButtonNextLevel { get; private set; }
    [field: SerializeField] public Button ButtonExitWin { get; private set; }
    [field: SerializeField] public Button ButtonReboot { get; private set; }
    [field: SerializeField] public Button ButtonExitLose { get; private set; }
}