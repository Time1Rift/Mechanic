using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct InfoSettingsUI
{
    [field: SerializeField] public GameObject SettingsScreen { get; private set; }

    [field: SerializeField] public List<Sprite> SpritesAudio { get; private set; }
    [field: SerializeField] public AudioSource AudioSource { get; private set; }
    [field: SerializeField] public Image ButtonIconSound { get; private set; }

    [field: SerializeField] public Button ButtonSettings { get; private set; }
    [field: SerializeField] public Button ButtonExit { get; private set; }
    [field: SerializeField] public Button ButtonClose { get; private set; }
    [field: SerializeField] public Button ButtonReboot { get; private set; }
    [field: SerializeField] public Button ButtonSound { get; private set; }
}