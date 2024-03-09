using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : ButtonAbstract
{
    private List<Sprite> _spritesAudio;
    private AudioSource _audioSource;
    private Image _icon;
    private bool _isEnabled = true;

    public ButtonSound(Button button, List<Sprite> spritesAudio, AudioSource audioSource, Image icon) : base(button)
    {
        _spritesAudio = spritesAudio;
        _audioSource = audioSource;
        _icon = icon;

        if (PlayerPrefs.HasKey("isBoolAudio"))
            _isEnabled = Convert.ToBoolean(PlayerPrefs.GetInt("isBoolAudio"));

        ChangeAudio();
    }

    protected override void OnButtonClick()
    {
        _isEnabled = !_isEnabled;
        ChangeAudio();

        PlayerPrefs.SetInt("isBoolAudio", Convert.ToInt32(_isEnabled));
    }

    private void ChangeAudio()
    {
        _icon.sprite = _spritesAudio[Convert.ToInt32(_isEnabled)];
        _audioSource.enabled = _isEnabled;
    }
}