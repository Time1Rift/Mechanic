using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoltInteractionHandler))]
public class Bolt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberText;
    [SerializeField] private MeshRenderer _material;

    private BoltInteractionHandler _interactionHandler;

    public Vector3 Parent { get; private set; }
    public int Number { get; private set; }

    public event Action<Bolt> Pressed;

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

    public void Initialize(int number, Color material, Vector3 parent)
    {
        _numberText.text = number.ToString();
        _material.material.color = material;
        Number = number;
        Parent = parent;
    }

    public void Enable() => _interactionHandler.Enable(true);

    private void OnPressed() => Pressed?.Invoke(this);
}