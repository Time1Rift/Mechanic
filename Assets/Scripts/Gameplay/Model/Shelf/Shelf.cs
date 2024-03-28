using System.Collections.Generic;

public class Shelf
{
    private List<Bolt> _bolts = new();
    private BoltSpawner _spawner;
    private int _maxBolts;

    public Shelf(BoltSpawner spawner, int maxBolts)
    {
        _spawner = spawner;
        _maxBolts = maxBolts;
    }

    public bool IsShelfFull => _bolts.Count == _maxBolts;
    public int CountBolts => _bolts.Count;
    public IReadOnlyList<Bolt> Bolts => _bolts;

    public void Remove(Bolt bolt) => _bolts.Remove(bolt);

    public void DisableBolt(Bolt bolt) => _spawner.SetObgect(bolt);

    public void ClearShelf()
    {
        if (CountBolts == 0)
            return;

        for (int i = 0; i < _bolts.Count; i++)
            DisableBolt(_bolts[i]);

        _bolts.Clear();
    }

    public void AddBolt(Bolt bolt) => _bolts.Add(bolt);

    public Bolt GetBolt(int number) => _spawner.GetBolt(number);
}