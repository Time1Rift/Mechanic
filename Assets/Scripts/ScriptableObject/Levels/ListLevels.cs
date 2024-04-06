using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New ListLevels", menuName = "Levels/Create new ListLevels", order = 51)]
public class ListLevels : ScriptableObject
{
    [field: SerializeField] public List<Level> Levels { get; private set; }

    public int CountLevels => Levels.Count;

    public Figure GetConstruction(int number) => Levels.FirstOrDefault(item => item.Number == number).Construction;
}