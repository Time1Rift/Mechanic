using System;
using TMPro;
using UnityEngine;

public class CompositeRootConstruction : MonoBehaviour
{
    [SerializeField] private BoltSpawner _boltSpawner;
    [SerializeField] private Transform _model;

    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private TextMeshProUGUI _numberText;

    private ConstructionView _view;
    private Construction _construction;

    private void Awake()
    {
        _view = new ConstructionView(_rectTransform, _numberText);
        _construction = new Construction(_model, _view);
    }

    private void Start()
    {
        _construction.SetDetail();
    }

    private void OnEnable()
    {
        _boltSpawner.BoltCreated += OnBoltCreated;
    }

    private void OnDisable()
    {
        _boltSpawner.BoltCreated -= OnBoltCreated;
    }

    private void OnBoltCreated(Bolt bolt) => _construction.Subscribe(bolt);
}