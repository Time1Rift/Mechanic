using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoltSpawner : ObjectPool<Bolt>, IBoltCreated
{
    [SerializeField] private List<VarietyBolt> _varietyBolts;
    [SerializeField] private Bolt _boltPrebab;

    private Bolt _newBolt;

    public int CountVarietyBolt => _varietyBolts.Count;

    public event System.Action<Bolt> BoltCreated;

    private void OnValidate()
    {
        var varietyBoltsDuplicates = _varietyBolts.GroupBy(item => item.Number)
            .Where(array => array.Count() > 1);

        if (varietyBoltsDuplicates.Count() > 0)
            throw new System.InvalidOperationException(nameof(_varietyBolts));
    }

    public Bolt GetBolt(int number)
    {
        Mathf.Clamp(number, 0, _varietyBolts.Count);
        _newBolt = GetObject(_boltPrebab);
        _newBolt.Initialize(_varietyBolts[number].Number, _varietyBolts[number].Mesh);
        _newBolt.gameObject.SetActive(true);
        BoltCreated?.Invoke(_newBolt);

        return _newBolt;
    }

    public Bolt GetBolt() => GetBolt(Random.Range(0, _varietyBolts.Count));
}