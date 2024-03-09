using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Constructions", menuName = "Constructions/Create new Constructions", order = 51)]
public class Constructions : ScriptableObject
{
    [field: SerializeField] public List<ConstructionPrefab> CountConstruction { get; private set; }

    public int Count => CountConstruction.Count;

    public void SetConstruction(ConstructionPrefab prefab) => CountConstruction.Add(prefab);
}