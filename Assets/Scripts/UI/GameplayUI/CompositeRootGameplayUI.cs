using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompositeRootGameplayUI : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private GameObject _windowSettings;

    [Header("Audio")]
    [SerializeField] private List<Sprite> _spritesAudio;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image _audioIcon;

    [Header("Button")]
    [SerializeField] private Button _buttonSettings;
    [SerializeField] private Button _buttonExit;
    [SerializeField] private Button _buttonClose;
    [SerializeField] private Button _buttonReboot;
    [SerializeField] private Button _buttonSound;

    private ButtonSettings _settings;
    private ButtonClose _close;
    private ButtonReboot _reboot;
    private ButtonExit _exit;
    private ButtonSound _sound;

    private void Awake()
    {
        _settings = new ButtonSettings(_buttonSettings, _windowSettings);
        _close = new ButtonClose(_buttonClose, _windowSettings);
        _reboot = new ButtonReboot(_buttonReboot);
        _sound = new ButtonSound(_buttonSound, _spritesAudio, _audioSource, _audioIcon);
        _exit = new ButtonExit(_buttonExit);
    }

    private void OnEnable()
    {
        _settings.Enabled();
        _close.Enabled();
        _reboot.Enabled();
        _sound.Enabled();
        _exit.Enabled();
    }

    private void OnDisable()
    {
        _settings.Disable();
        _close.Disable();
        _reboot.Disable();
        _sound.Disable();
        _exit.Disable();
    }
}