using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShelfConnector
{
    private int _countBoltsAddition;
    private BoltSpawner _spawner;

    public ShelfConnector(int countBoltsAddition, BoltSpawner spawner)
    {
        _spawner = spawner;
        _countBoltsAddition = countBoltsAddition;
    }

    public void TryRemove(Bolt bolt, List<Bolt> bolts)
    {
        bolt.Relocate();

        if (bolt.IsText == false)
            bolts.Remove(bolt);
    }    

    public void FoldBolts(List<Bolt> bolts, Transform transform)
    {
        var itemsDuplicates = bolts.GroupBy(item => item.Number)
            .Where(array => array.Count() == _countBoltsAddition)
            .FirstOrDefault();

        if (itemsDuplicates != null)
        {
            foreach (var bolt in itemsDuplicates)
            {
                bolts.Remove(bolt);
                _spawner.PutObject(bolt);
            }

            Bolt newBolt = _spawner.GetBolt(itemsDuplicates.Key);
            newBolt.transform.SetParent(transform);
            bolts.Add(newBolt);
            
            TryRemove(newBolt, bolts);
        }
    }
}