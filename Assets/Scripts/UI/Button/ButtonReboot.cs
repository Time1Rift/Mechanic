using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonReboot : ButtonAbstract, IPressed
{
    private GameObject _screen;

    public ButtonReboot(Button button, GameObject screen) : base(button) 
    {
        _screen = screen;
    }

    public event Action ShelfCleared;
    public event Action<bool> Pressed;

    protected override void OnButtonClick()
    {
        ShelfCleared?.Invoke();
        _screen.SetActive(false);
        Pressed?.Invoke(true);
    }
}