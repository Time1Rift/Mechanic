using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoltSpawner : ObjectPool<Bolt>
{
    [SerializeField] private List<VarietyBolt> _varietyBolts;
    [SerializeField] private Bolt _boltPrebab;
    [SerializeField] private Shelf _shelf;

    private void OnValidate()
    {
        var varietyBoltsDuplicates = _varietyBolts.GroupBy(item => item.Number)
            .Where(array => array.Count() > 1);

        if (varietyBoltsDuplicates.Count() > 0)
            throw new System.InvalidOperationException(nameof(_varietyBolts));
    }

    public Bolt GetBolt(Vector3 parent)
    {
        VarietyBolt varietyBolt = _varietyBolts[Random.Range(0, _varietyBolts.Count)];

        Bolt newBolt = GetObject(_boltPrebab);
        newBolt.Initialize(varietyBolt.Number, varietyBolt.Color, parent);
        newBolt.gameObject.SetActive(true);

        _shelf.SubscribeBolt(newBolt);

        return newBolt;
    }
}