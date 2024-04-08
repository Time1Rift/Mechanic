using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ListLevels", menuName = "Levels/Create new ListLevels", order = 51)]
public class ListLevels : ScriptableObject
{
    [field: SerializeField] public List<Level> Levels { get; private set; }

    public int CountLevels => Levels.Count;
}