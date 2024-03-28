using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct InfoPauseUI
{
    [field: SerializeField] public GameObject PauseScreen { get; private set; }
    [field: SerializeField] public Button ButtonPause { get; private set; }
    [field: SerializeField] public Button ButtonExit { get; private set; }
    [field: SerializeField] public Button ButtonClose { get; private set; }
    [field: SerializeField] public Button ButtonReboot { get; private set; }
}