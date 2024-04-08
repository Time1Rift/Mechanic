using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClose : AbstractButton, IPressed
{
    private GameObject _window;

    public ButtonClose(Button button, AudioSource audioSource, GameObject window) : base(button, audioSource)
    {
        _window = window;
    }

    public event Action<bool> Pressed;

    protected override void Activate()
    {
        _window.SetActive(false);
        Pressed?.Invoke(true);
    }
}