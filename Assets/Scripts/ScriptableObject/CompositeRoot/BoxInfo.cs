using UnityEngine;

[CreateAssetMenu(fileName = "BoxInfo", menuName = "CompositeRoot/Create new BoxInfo", order = 51)]
public class BoxInfo : ScriptableObject
{
    [field: SerializeField, Min(0f)] public float OffsetLines { get; private set; } = 1f;
    [field: SerializeField, Min(0)] public int CountLines { get; private set; } = 6;
    [field: SerializeField, Min(0f)] public float OffsetColumns { get; private set; } = 1.1f;
}