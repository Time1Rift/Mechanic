using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop
{
    private CellShopSpawner _cellShopSpawner;
    private PurchasedCellShops _purchasedCellShops;
    private Wallet _wallet;
    private PlayerDataPurchasedCubes _purchasedCubes;
    private List<VarietyBolt> _purchasedVarietyBolts = new();
    private List<VarietyBolt> _varietyBolts = new();

    public Shop(ListVarietyBolts bolts, CellShopSpawner cellShopSpawner, Wallet wallet, PurchasedCellShops purchasedCellShops)
    {
        _cellShopSpawner = cellShopSpawner;
        _purchasedCellShops = purchasedCellShops;
        _wallet = wallet;
        _purchasedCubes = new PlayerDataPurchasedCubes();
        _purchasedVarietyBolts = _purchasedCubes.GetCubes(bolts);
        _varietyBolts = bolts.VarietyBolts;
    }

    public void Start()
    {
        foreach (var item in _varietyBolts)
            AddItem(item, _purchasedVarietyBolts, _cellShopSpawner);
    }

    private void AddItem(VarietyBolt varietyBolt, List<VarietyBolt> purchasedVarietyBolts, CellShopSpawner cellShopSpawner)
    {
        CellShop newCellShop = cellShopSpawner.GetCellShop(varietyBolt);
        
        if (purchasedVarietyBolts.FirstOrDefault(item => item.Number == varietyBolt.Number) == null)
        {
            newCellShop.SellButtonClick += OnSellButtonClick;
            newCellShop.EnableLock();
        }
        else
        {
            _purchasedCellShops.AddCellShop(newCellShop);
        }
    }

    private void OnSellButtonClick(CellShop cellShop, VarietyBolt varietyBolt)
    {
        TrySellWeapon(cellShop, varietyBolt);
    }

    private void TrySellWeapon(CellShop cellShop, VarietyBolt varietyBolt)
    {
        if (_wallet.CountCoins >= varietyBolt.Price)
        {
            _purchasedCellShops.AddCellShop(cellShop);
            cellShop.SellButtonClick -= OnSellButtonClick;
            cellShop.DisableLock();
            _wallet.RemoveCoins(varietyBolt.Price);
            _purchasedCubes.ChangeCubes(varietyBolt.Number);
        }
    }
}