using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
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
    [field: SerializeField] public AudioSource ButtonSound { get; private set; }
    [field: SerializeField] public AudioMixerGroup Mixer { get; private set; }
    [field: SerializeField] public List<GameObject> SpritesMusic { get; private set; }
    [field: SerializeField] public Button ButtonEffectSound { get; private set; }
    [field: SerializeField] public List<GameObject> SpritesEffectSound { get; private set; }
}