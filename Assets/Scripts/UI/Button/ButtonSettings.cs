using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSettings : ButtonAbstract, IPressed
{
    private GameObject _windowSettings;

    public ButtonSettings(Button button, GameObject windowSettings) : base(button)
    {
        _windowSettings = windowSettings;
        _windowSettings.SetActive(false);
    }

    public event Action<bool> Pressed;

    protected override void OnButtonClick()
    {
        _windowSettings.SetActive(true);
        Pressed?.Invoke(false);
    }
}