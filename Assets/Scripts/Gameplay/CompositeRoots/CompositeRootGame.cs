using UnityEngine;

public class CompositeRootGame : MonoBehaviour
{
    [SerializeField] private CompositeRootGameplayUI _gameplayUI;
    [SerializeField] private CompositeRootShelf _shelf;
    [SerializeField] private CompositeRootConstruction _construction;
    [SerializeField] private CompositeRootCoins _coins;

    [SerializeField] private GameObject _shelfObject;
    [SerializeField] private GameObject _boxObject;

    public void Enable()
    {
        _construction.GetIWin().Win += OnWin;
        _shelf.GetILosed().Losed += OnLosed;

        foreach (var item in _gameplayUI.Subscribe())
            item.Pressed += OnPressed;
    }

    public void Disable()
    {
        _construction.GetIWin().Win -= OnWin;
        _shelf.GetILosed().Losed -= OnLosed;

        foreach (var item in _gameplayUI.Subscribe())
            item.Pressed -= OnPressed;
    }

    private void OnWin()
    {
        UpdateData();
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

    private void UpdateData()
    {
        _coins.AddCoins();
        PlayerDataMaxAvailableLevel maxAvailableLevel = new PlayerDataMaxAvailableLevel();
        PlayerDataSelectedLevel selectedLevel = new PlayerDataSelectedLevel();

        if (selectedLevel.GetValue() == maxAvailableLevel.GetValue())
            maxAvailableLevel.NextValue();
    }
}