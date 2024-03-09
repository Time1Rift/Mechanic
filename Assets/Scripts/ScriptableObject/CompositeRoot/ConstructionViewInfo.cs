using UnityEngine;

[CreateAssetMenu(fileName = "ConstructionViewInfo", menuName = "CompositeRoot/Create new ConstructionViewInfo", order = 51)]
public class ConstructionViewInfo : ScriptableObject
{
    [field: SerializeField, Min(0f)] public float DurationMover { get; private set; } = 0.6f;
}