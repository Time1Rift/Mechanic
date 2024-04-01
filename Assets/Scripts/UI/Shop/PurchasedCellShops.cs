using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PurchasedCellShops
{
    private List<CellShop> _cellShop = new();

    public event Action<CellShop> CellShopAdded;

    public IReadOnlyList<CellShop> CellShop => _cellShop;

    public void AddCellShop(CellShop cellShop)
    {
        _cellShop.Add(cellShop);
        CellShopAdded?.Invoke(cellShop);
    }

    public void EnableSelectionButtons(List<ActiveCube> activeCubes)
    {
        foreach (var cellShop in _cellShop)
        {
            ActiveCube ActiveCube = activeCubes.FirstOrDefault(item => item.VarietyBolt == cellShop.VarietyBolt);

            if (ActiveCube != null)
                cellShop.DisableSelectionButton();
            else
                cellShop.EnableSelectionButton();
        }
    }
}