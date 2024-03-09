using UnityEngine;

[CreateAssetMenu(fileName = "ShelfViewInfo", menuName = "CompositeRoot/Create new ShelfViewInfo", order = 51)]
public class ShelfViewInfo : ScriptableObject
{
    [field: SerializeField, Min(0f)] public float Offset { get; private set; } = 1.1f;
    [field: SerializeField, Min(0f)] public float DurationMover { get; private set; } = 0.2f;
    [field: SerializeField, Min(0f)] public float DurationConnected { get; private set; } = 0.2f;
    [field: SerializeField, Min(0f)] public float DurationScale { get; private set; } = 0.2f;
    [field: SerializeField, Min(0f)] public float MaxScale { get; private set; } = 0.8f;
    [field: SerializeField, Min(0f)] public float MinScale { get; private set; } = 1.2f;
}