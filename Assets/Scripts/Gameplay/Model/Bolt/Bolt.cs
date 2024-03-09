using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoltInteractionHandler))]
public class Bolt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberText;
    [SerializeField] private MeshFilter _mesh;

    private BoltInteractionHandler _interactionHandler;

    public int Number { get; private set; }
    public bool IsText => _numberText.enabled;

    public event Action<Bolt> Pressed;
    public event Action<Bolt> Postponed;

    private void Awake()
    {
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

    public void CanTrackClicks(bool isWorking) => _interactionHandler.CanTrackClicks(isWorking);

    private void OnPressed() => Pressed?.Invoke(this);
}