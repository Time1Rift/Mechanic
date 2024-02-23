using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoltSpawner : ObjectPool<Bolt>
{
    [SerializeField] private List<VarietyBolt> _varietyBolts;
    [SerializeField] private Bolt _boltPrebab;

    public event System.Action<Bolt> BoltCreated;

    private void OnValidate()
    {
        var varietyBoltsDuplicates = _varietyBolts.GroupBy(item => item.Number)
            .Where(array => array.Count() > 1);

        if (varietyBoltsDuplicates.Count() > 0)
            throw new System.InvalidOperationException(nameof(_varietyBolts));
    }

    public Bolt GetBolt(Vector3 parent, int number)
    {
        VarietyBolt varietyBolt = _varietyBolts[number];

        Bolt newBolt = GetObject(_boltPrebab);
        newBolt.Initialize(varietyBolt.Number, varietyBolt.Color, parent);
        newBolt.gameObject.SetActive(true);

        BoltCreated?.Invoke(newBolt);

        return newBolt;
    }

    public Bolt GetBolt(Vector3 parent) => GetBolt(parent, Random.Range(0, _varietyBolts.Count));
}