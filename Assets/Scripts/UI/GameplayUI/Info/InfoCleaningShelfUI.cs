using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct InfoCleaningShelfUI
{
    [field: SerializeField] public GameObject CleaningShelfScreen { get; private set; }
    [field: SerializeField] public Button ButtonCleaningShelf { get; private set; }
    [field: SerializeField] public Button ButtonClose { get; private set; }
    [field: SerializeField] public Button ButtonCoins { get; private set; }
    [field: SerializeField] public Button ButtonAdvertisement { get; private set; }
    [field: SerializeField] public Button ButtonCleaningShelfVideoAd { get; private set; }
    [field: SerializeField] public AudioSource AudioSource { get; private set; }
    [field: SerializeField] public GameObject WalletScreen { get; private set; }
}