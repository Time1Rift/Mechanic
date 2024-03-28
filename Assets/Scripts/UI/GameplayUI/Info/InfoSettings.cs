using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct InfoSettings
{
    [field: SerializeField] public GameObject SettingsScreen { get; private set; }
    [field: SerializeField] public Button ButtonSettings { get; private set; }
    [field: SerializeField] public Button ButtonClose { get; private set; }
    [field: SerializeField] public Button ButtonMusic { get; private set; }
    //[field: SerializeField] public Button ButtonSounds { get; private set; }
    // смена языка
    
    [field: SerializeField] public AudioSource AudioSource { get; private set; }
    [field: SerializeField] public List<Sprite> SpritesAudio { get; private set; }
    [field: SerializeField] public Image ButtonIconSound { get; private set; }
}