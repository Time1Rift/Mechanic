using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoltInteractionHandler))]
public class Bolt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberText;
    [SerializeField] private MeshFilter _mesh;

    private BoltInteractionHandler _interactionHandler;
    private Transform _transform;

    public int Number { get; private set; }
    public bool IsText => _numberText.enabled;
    public Transform Transform => _transform;

    public event Action<Bolt> Pressed;
    public event Action<Bolt> Postponed;

    private void Awake()
    {
        _transform = transform;
        _interactionHandler = GetComponent<BoltInteractionHandler>();
    }

    private void OnEnable()
    {
        _interactionHandler.Pressed += OnPressed;
    }

    private void OnDisable()
    {
        _interactionHandler.Pressed -= OnPressed;
    }

    public void Initialize(int number, Mesh mesh)
    {
        _numberText.text = number.ToString();
        _numberText.enabled = true;
        _mesh.mesh = mesh;
        Number = number;
    }

    public void DisableText() => _numberText.enabled = false;

    public void Relocate() => Postponed?.Invoke(this);

    public void ActivateClick() => _interactionHandler.ActivateClick();

    private void OnPressed() => Pressed?.Invoke(this);
}