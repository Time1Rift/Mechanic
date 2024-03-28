using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMusic : ButtonAbstract
{
    private List<Sprite> _spritesAudio;
    private AudioSource _audioSource;
    private Image _icon;
    private bool _isEnabled = true;
    private PlayerDataMusic _playerData;

    public ButtonMusic(Button button, List<Sprite> spritesAudio, AudioSource audioSource, Image icon) : base(button)
    {
        _spritesAudio = spritesAudio;
        _audioSource = audioSource;
        _icon = icon;

        _playerData = new PlayerDataMusic();
        _isEnabled = _playerData.IsEnabledMusic;

        ChangeAudio();
    }

    protected override void OnButtonClick()
    {
        _isEnabled = !_isEnabled;
        ChangeAudio();
        _playerData.IsEnabledMusic = _isEnabled;
    }

    private void ChangeAudio()
    {
        _icon.sprite = _spritesAudio[Convert.ToInt32(_isEnabled)];
        _audioSource.enabled = _isEnabled;
    }
}