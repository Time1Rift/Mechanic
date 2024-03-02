using UnityEngine;

[CreateAssetMenu(fileName = "ShelfInfo", menuName = "CompositeRoot/Create new ShelfInfo", order = 51)]
public class ShelfInfo : ScriptableObject
{
    [field: SerializeField, Min(0f)] public float Offset { get; private set; } = 1.1f;
    [field: SerializeField, Min(0)] public int MaxBolts { get; private set; } = 5;
    [field: SerializeField, Min(0)] public int CountBoltsAddition { get; private set; } = 3;
}