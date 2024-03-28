using System.Collections.Generic;
using UnityEngine;

public class ShelfActiveCubes
{
    private PurchasedCellShops _purchasedCellShops;
    private List<ActiveCube> _activeCubes = new();
    private ActiveCube _curentActiveCube;
    private PlayerDataActiveVarietyCubs _dateActiveCubs;
    private List<VarietyBolt> _activeVarietyCubs = new();

    public ShelfActiveCubes(ListVarietyBolts bolts, List<ActiveCube> activeCubes, PurchasedCellShops purchasedCellShops)
    {
        _purchasedCellShops = purchasedCellShops;
        _activeCubes = activeCubes;
        _dateActiveCubs = new PlayerDataActiveVarietyCubs();
        _activeVarietyCubs = new PlayerDataActiveVarietyCubs().GetCubes(bolts);
    }

    public void Enable()
    {
        for (int i = 0; i < _activeCubes.Count; i++)
        {
            _activeCubes[i].Render(_activeVarietyCubs[i]);
            _activeCubes[i].Presed += OnPresed;
        }

        _purchasedCellShops.CellShopAdded += OnCellShopAdded;
    }

    public void Disable()
    {
        _purchasedCellShops.CellShopAdded -= OnCellShopAdded;

        for (int i = 0; i < _activeCubes.Count; i++)
            _activeCubes[i].Presed -= OnPresed;
    }

    private void OnCellShopAdded(CellShop cellShop)
    {
        cellShop.SelectionButtonClick += OnSelectionButtonClick;

        if (_curentActiveCube != null)
            cellShop.EnableSelectionButton();
    }
     
    private void OnSelectionButtonClick(VarietyBolt varietyBolt)
    {
        _curentActiveCube.Render(varietyBolt);
        _dateActiveCubs.ChangeCubes(varietyBolt.Number, _activeCubes.IndexOf(_curentActiveCube));
        OnPresed(_curentActiveCube);
    }

    private void OnPresed(ActiveCube activeCube)
    {
        _curentActiveCube = activeCube;

        foreach (var item in _activeCubes)
            if (item != _curentActiveCube)
                item.EnableLock();

        _purchasedCellShops.EnableSelectionButtons(_activeCubes);
    }
}