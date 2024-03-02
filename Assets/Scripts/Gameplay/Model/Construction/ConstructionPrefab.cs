using TMPro;
using UnityEngine;

public class ConstructionPrefab : MonoBehaviour
{
    [field: SerializeField] public Transform Model { get; private set; }
    [field: SerializeField] public RectTransform RectTransform { get; private set; }
    [field: SerializeField] public TextMeshProUGUI NumberText { get; private set; }
}