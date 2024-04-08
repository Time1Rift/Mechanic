using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonWindowOpening : AbstractButton, IPressed
{
    private GameObject _window;

    public ButtonWindowOpening(Button button, AudioSource audioSource, GameObject window) : base(button, audioSource)
    {
        _window = window;
        _window.SetActive(false);
    }

    public event Action<bool> Pressed;

    protected override void Activate()
    {
        _window.SetActive(true);
        Pressed?.Invoke(false);
    }
}