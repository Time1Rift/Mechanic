using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct InfoSettings
{
    [field: SerializeField] public GameObject SettingsScreen { get; private set; }
    [field: SerializeField] public Button ButtonSettings { get; private set; }
    [field: SerializeField] public Button ButtonClose { get; private set; }
    [field: SerializeField] public Button ButtonMusic { get; private set; }
    [field: SerializeField] public TMP_Dropdown Dropdown { get; private set; }
    [field: SerializeField] public Localization Localization { get; private set; }
    
    [field: SerializeField] public AudioSource AudioSource { get; private set; }
    [field: SerializeField] public List<GameObject> SpritesAudio { get; private set; }
}