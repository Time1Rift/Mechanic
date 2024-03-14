using UnityEngine;

public class PartDetail : MonoBehaviour
{
    [field: SerializeField, Range(1, 4)] public int Number { get; private set; }

    private Transform _transform;

    public Transform Transform => _transform;

    private void OnValidate()
    {
        gameObject.name = Number.ToString();
    }

    private void Awake()
    {
        _transform = transform;
    }
}