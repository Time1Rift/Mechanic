using TMPro;
using UnityEngine;

public class ConstructionPrefab : MonoBehaviour
{
    [field: SerializeField] public Transform Model { get; private set; }
    [field: SerializeField] public Transform Preview { get; private set; }
    [field: SerializeField] public TextMeshProUGUI NumberText { get; private set; }
}