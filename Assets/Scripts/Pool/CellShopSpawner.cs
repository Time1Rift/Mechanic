using UnityEngine;

public class CellShopSpawner : ObjectPool<CellShop>
{
    [SerializeField] private CellShop _prefabe;

    private CellShop _newPrefabe;

    public CellShop GetCellShop(VarietyBolt varietyBolt)
    {
        _newPrefabe = GetObject(_prefabe);
        _newPrefabe.Render(varietyBolt);
        _newPrefabe.gameObject.SetActive(true);
        return _newPrefabe;
    }
}