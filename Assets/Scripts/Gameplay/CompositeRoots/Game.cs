using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private CompositeRootGameplayUI _gameplayUI;
    [SerializeField] private CompositeRootBox _box;
    [SerializeField] private CompositeRootShelf _shelf;
    [SerializeField] private CompositeRootConstruction _construction;

    [SerializeField] private GameObject _shelfObject;
    [SerializeField] private GameObject _boxObject;

    private void Awake()
    {
        _gameplayUI.Initialize();
        _box.Initialize();
        _shelf.Initialize();
        _construction.Initialize();
    }

    private void OnEnable()
    {
        _gameplayUI.Enable();
        _box.Enable();
        _shelf.Enable();
        _construction.Enable();

        _construction.GetIWin().Win += OnWin;
        _shelf.GetILosed().Losed += OnLosed;

        foreach (var item in _gameplayUI.Subscribe())
            item.Pressed += OnPressed;
    }

    private void OnDisable()
    {
        _gameplayUI.Disable();
        _box.Disable();
        _shelf.Disable();
        _construction.Disable();

        _construction.GetIWin().Win -= OnWin;
        _shelf.GetILosed().Losed -= OnLosed;

        foreach (var item in _gameplayUI.Subscribe())
            item.Pressed -= OnPressed;
    }

    private void OnWin()
    {
        _gameplayUI.Win();
        OnPressed(false);
    }

    private void OnLosed()
    {
        _gameplayUI.Lose();
        OnPressed(false);
    }

    private void OnPressed(bool isWorking)
    {
        _construction.ShowEntireStructure(isWorking);
        _shelfObject.SetActive(isWorking);
        _boxObject.SetActive(isWorking);
    }
}