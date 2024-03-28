using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct InfoShopUI
{
    [field: SerializeField] public GameObject ShopScreen { get; private set; }
    [field: SerializeField] public Button ButtonShop { get; private set; }
    [field: SerializeField] public Button ButtonClose { get; private set; }
    [field: SerializeField] public TextMeshProUGUI WalletText { get; private set; }
    [field: SerializeField] public ListVarietyBolts Bolts { get; private set; }
    [field: SerializeField] public CellShopSpawner CellShopSpawner { get; private set; }
    [field: SerializeField] public List<ActiveCube> ActiveCubes { get; private set; }
}