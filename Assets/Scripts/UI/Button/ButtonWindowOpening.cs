using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonWindowOpening : ButtonAbstract, IPressed
{
    private GameObject _window;

    public ButtonWindowOpening(Button button, GameObject window) : base(button)
    {
        _window = window;
        _window.SetActive(false);
    }

    public event Action<bool> Pressed;

    protected override void OnButtonClick()
    {
        _window.SetActive(true);
        Pressed?.Invoke(false);
    }
}