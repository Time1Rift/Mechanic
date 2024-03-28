using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ListVarietyBolts", menuName = "Bolt/Create new ListVarietyBolts", order = 51)]
public class ListVarietyBolts : ScriptableObject
{
    [field: SerializeField, Min(0)] public List<VarietyBolt> VarietyBolts { get; private set; }

    public VarietyBolt GetVarietyBolt(int number) => VarietyBolts.FirstOrDefault(item => item.Number == number);
}