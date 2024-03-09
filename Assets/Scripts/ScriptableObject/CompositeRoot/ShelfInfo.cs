using UnityEngine;

[CreateAssetMenu(fileName = "ShelfInfo", menuName = "CompositeRoot/Create new ShelfInfo", order = 51)]
public class ShelfInfo : ScriptableObject
{
    [field: SerializeField, Min(0)] public int CountBoltsAddition { get; private set; } = 3;
    [field: SerializeField, Min(0)] public int MaxBolts { get; private set; } = 5;
}