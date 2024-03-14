using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShelfInspector
{
    private int _countBoltsAddition;
    private int _maxBolts;
    private int _countVarietyBolt;

    public ShelfInspector(int countBoltsAddition, int maxBolts, int countVarietyBolt)
    {
        _countBoltsAddition = countBoltsAddition;
        _maxBolts = maxBolts;
        _countVarietyBolt = countVarietyBolt;
    }

    public bool TryLosed(int number) => number == _maxBolts;

    public bool TryRemove(IEnumerable<Bolt> bolts, out Bolt bolt)
    {
        bolt = null;

        foreach (var item in bolts)
        {
            item.Relocate();

            if (item.IsText == false)
            {
                bolt = item;
                return true;
            }
        }

        return false;
    }

    public bool FoldBolts(IEnumerable<Bolt> bolts, out IGrouping<int, Bolt> duplicates)
    {
        duplicates = bolts.GroupBy(item => item.Number)
            .Where(array => array.Count() == _countBoltsAddition)
            .FirstOrDefault(item => item.Key < _countVarietyBolt);

        return duplicates != null;
    }
}