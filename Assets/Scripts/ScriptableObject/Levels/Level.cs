using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Levels/Create new Level", order = 51)]
public class Level : ScriptableObject
{
    [field: SerializeField, Min(1)] public int Number { get; private set; }
    [field: SerializeField] public string NameFile { get; private set; }
    [field: SerializeField] public Figure Figure { get; private set; }
}