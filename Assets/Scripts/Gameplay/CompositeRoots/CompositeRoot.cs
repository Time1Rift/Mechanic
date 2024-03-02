using System.Collections.Generic;
using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private BoxInfo _boxInfo;
    [SerializeField] private ShelfInfo _shelfInfo;
    [SerializeField] private Transform _shelTransform;
    [SerializeField] private List<ConstructionPrefab> _prefabs;
    [SerializeField] private BoltSpawner _boltSpawner;

    private CompositeRootBox _box;
    private CompositeRootShelf _shelf;
    private CompositeRootConstruction _constructions;

    private void Awake()
    {
        _box = new CompositeRootBox(_boxInfo, _boltSpawner);
        _shelf = new CompositeRootShelf(_shelfInfo, _shelTransform, _boltSpawner);
        ConstructionPrefab newConstructio = Instantiate(_prefabs[Random.Range(0, _prefabs.Count)]);
        _constructions = new CompositeRootConstruction(newConstructio);
    }

    private void Start()
    {
        _box.Start();
        _constructions.Start();
    }

    private void OnEnable()
    {
        _box.Enable();
        _shelf.Enable();
        _constructions.Enable(_boltSpawner);

        _constructions.GetIWin().Win += OnWin;
        _shelf.GetILosed().Losed += OnLosed;
    }

    private void OnDisable()
    {
        _box.Disable();
        _shelf.Disable();
        _constructions.Disable(_boltSpawner);

        _constructions.GetIWin().Win -= OnWin;
        _shelf.GetILosed().Losed -= OnLosed;
    }

    private void OnWin()
    {
        Debug.Log("Win");
    }

    private void OnLosed()
    {
        Debug.Log("Lose");
    }
}