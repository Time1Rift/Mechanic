using System.Collections.Generic;
using System.Linq;

public class ShelfInspector
{
    private int _countBoltsAddition;
    private int _maxBolts;

    public ShelfInspector(int countBoltsAddition, int maxBolts)
    {
        _countBoltsAddition = countBoltsAddition;
        _maxBolts = maxBolts;
    }

    public bool TryLosed(int number) => number == _maxBolts;

    public bool TryRemove(Bolt bolt)
    {
        bolt.Relocate();
        return bolt.IsText == false;
    }

    public bool FoldBolts(IEnumerable<Bolt> bolts, out IGrouping<int, Bolt> duplicates)
    {
        duplicates = bolts.GroupBy(item => item.Number)
            .Where(array => array.Count() == _countBoltsAddition)
            .FirstOrDefault();

        return duplicates != null;
    }
}