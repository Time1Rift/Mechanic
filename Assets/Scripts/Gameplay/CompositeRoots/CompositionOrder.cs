using UnityEngine;

public class CompositionOrder : MonoBehaviour
{
    [SerializeField] private BoltSpawner _boltSpawner;
    [SerializeField] private CompositeRootGameplayUI _gameplayUI;
    [SerializeField] private CompositeRootBox _box;
    [SerializeField] private CompositeRootShelf _shelf;
    [SerializeField] private CompositeRootConstruction _construction;
    [SerializeField] private CompositeRootCoins _coins;
    [SerializeField] private CompositeRootGame _game;

    private void Awake()
    {
        _boltSpawner.Initialize();
        _gameplayUI.Initialize();
        _box.Initialize();
        _shelf.Initialize();
        _construction.Initialize();
        _coins.Initialize();
    }

    private void OnEnable()
    {
        _gameplayUI.Enable();
        _box.Enable();
        _shelf.Enable();
        _construction.Enable();
        _coins.Enable();
        _game.Enable();
    }

    private void OnDisable()
    {
        _gameplayUI.Disable();
        _box.Disable();
        _shelf.Disable();
        _construction.Disable();
        _coins.Disable();
        _game.Disable();
    }
}
