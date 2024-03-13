using UnityEngine;

[CreateAssetMenu(fileName = "ConstructionViewInfo", menuName = "CompositeRoot/Create new ConstructionViewInfo", order = 51)]
public class ConstructionViewInfo : ScriptableObject
{
    [field: SerializeField, Min(0f)] public float DurationMover { get; private set; } = 0.6f;
    [field: SerializeField, Min(0f)] public float MoveDuration { get; private set; } = 0.6f;
    [field: SerializeField, Min(0f)] public float DurationRotate { get; private set; } = 0.5f;
    [field: SerializeField] public Vector3 PositionIndentation { get; private set; }
    [field: SerializeField] public Vector3 SesignReviewPosition { get; private set; }
}