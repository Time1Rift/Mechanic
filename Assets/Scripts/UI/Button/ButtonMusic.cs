using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMusic : ButtonAbstract
{
    private List<GameObject> _spritesAudio;
    private AudioSource _audioSource;
    private bool _isEnabled = true;
    private PlayerDataMusic _playerData;

    public ButtonMusic(Button button, List<GameObject> spritesAudio, AudioSource audioSource) : base(button)
    {
        _spritesAudio = spritesAudio;
        _audioSource = audioSource;

        _playerData = new PlayerDataMusic();
        _isEnabled = _playerData.GetValue();

        ChangeAudio();
    }

    protected override void OnButtonClick()
    {
        _isEnabled = !_isEnabled;
        ChangeAudio();
        _playerData.SetValue(_isEnabled);
    }

    private void ChangeAudio()
    {
        _spritesAudio[0].SetActive(!_isEnabled);
        _spritesAudio[1].SetActive(_isEnabled);

        _audioSource.enabled = _isEnabled;
    }
}