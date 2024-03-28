using System.Collections.Generic;
using UnityEngine;

public class BoltSpawner : ObjectPool<Bolt>, IBoltCreated
{
    [SerializeField] private ListVarietyBolts _prefabe;
    [SerializeField] private Bolt _boltPrebab;

    private Bolt _newPrefabe;
    private List<VarietyBolt> _varietyBolts = new();
    private int _number;

    public int CountVarietyBolt => _varietyBolts.Count;

    public event System.Action<Bolt> BoltCreated;

    public void Initialize() => _varietyBolts = new PlayerDataActiveVarietyCubs().GetCubes(_prefabe);

    public Bolt GetBolt(int index)
    {
        _newPrefabe = GetObject(_boltPrebab);
        index = Mathf.Clamp(index, 0, _varietyBolts.Count);
        _number = index + 1;
        _newPrefabe.Initialize(_number, _varietyBolts[index].Mesh);
        _newPrefabe.gameObject.SetActive(true);
        BoltCreated?.Invoke(_newPrefabe);

        return _newPrefabe;
    }

    public Bolt GetBolt() => GetBolt(Random.Range(0, _varietyBolts.Count));
}