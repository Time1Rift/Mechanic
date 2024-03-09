using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClose : ButtonAbstract, IPressed
{
    private GameObject _windowSettings;

    public ButtonClose(Button button, GameObject windowSettings) : base(button)
    {
        _windowSettings = windowSettings;
    }

    public event Action<bool> Pressed;

    protected override void OnButtonClick()
    {
        _windowSettings.SetActive(false);
        Pressed?.Invoke(true);
    }
}