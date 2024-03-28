using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct InfoLevelsUI
{
    [field: SerializeField] public GameObject LevelsScreen { get; private set; }
    [field: SerializeField] public Button ButtonLevels { get; private set; }
    [field: SerializeField] public Button ButtonClose { get; private set; }
    [field: SerializeField] public ListLevels ListLevels { get; private set; }
    [field: SerializeField] public LevelUISpawner Spawner { get; private set; }
}