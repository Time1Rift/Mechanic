using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShelfSorter
{
    private Construction _construction;            //      не забыть это убрать
    private int _countBoltsAddition;
    private BoltSpawner _spawner;

    public ShelfSorter(int countBoltsAddition, Construction construction, BoltSpawner spawner)
    {
        _countBoltsAddition = countBoltsAddition;
        _construction = construction;
        _spawner = spawner;
    }

    public void CanNumber(List<Bolt> bolts)
    {
        for (int i = 0; i < bolts.Count; i++)
        {
            if (_construction.TryNumber(bolts[i].Number))
            {
                _construction.SetBolt(bolts[i]);
                bolts.Remove(bolts[i]);
                return;
            }
        }
    }

    public void FoldBolts(List<Bolt> bolts, Transform transform)
    {
        var itemsDuplicates = bolts.GroupBy(item => item.Number)
            .Where(array => array.Count() == _countBoltsAddition);

        if (itemsDuplicates.Count() > 0)
        {
            var duplicat = itemsDuplicates.FirstOrDefault();

            foreach (var bolt in duplicat)
            {
                bolts.Remove(bolt);
                _spawner.PutObject(bolt);
            }

            Bolt newBolt = _spawner.GetBolt(duplicat.Key);
            newBolt.transform.SetParent(transform);
            bolts.Add(newBolt);

            CanNumber(bolts);
        }
    }
}