using UnityEngine;

[CreateAssetMenu(fileName = "New Bolt", menuName = "Bolt/Create new Bolt", order = 51)]
public class VarietyBolt : ScriptableObject
{
    [field: SerializeField, Min(0)] public int Number { get; private set; }
    [field: SerializeField] public Mesh Mesh { get; private set; }
}