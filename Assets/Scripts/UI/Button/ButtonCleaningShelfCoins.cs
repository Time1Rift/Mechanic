using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCleaningShelfCoins : AbstractButton, IPressed, IShelfCleared, IButtonCleaningShelfCoins
{
    private GameObject _window;

    public ButtonCleaningShelfCoins(Button button, AudioSource audioSource, GameObject window) : base(button, audioSource)
    {
        _window = window;
    }

    public event Action<IButtonCleaningShelfCoins> TriedPay;
    public event Action ShelfCleared;
    public event Action<bool> Pressed;

    public void ClearShelf()
    {
        _window.SetActive(false);
        Pressed?.Invoke(true);
        ShelfCleared?.Invoke();
    }

    protected override void Activate()
    {
        TriedPay?.Invoke(this);
    }
}