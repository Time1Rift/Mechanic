using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClose : ButtonAbstract, IPressed
{
    private GameObject _window;

    public ButtonClose(Button button, GameObject window) : base(button)
    {
        _window = window;
    }

    public event Action<bool> Pressed;

    protected override void OnButtonClick()
    {
        _window.SetActive(false);
        Pressed?.Invoke(true);
    }
}