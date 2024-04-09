using UnityEngine;

public class CellShopSpawner : ObjectPool<CellShop>
{
    [SerializeField] private CellShop _prefabe;
    [SerializeField] private AudioSource _audioSource;

    private CellShop _newPrefabe;

    public CellShop GetCellShop(VarietyBolt varietyBolt)
    {
        _newPrefabe = GetObject(_prefabe);
        _newPrefabe.Render(varietyBolt, _audioSource);
        _newPrefabe.gameObject.SetActive(true);
        return _newPrefabe;
    }
}