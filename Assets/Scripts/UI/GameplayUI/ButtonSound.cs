using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : ButtonAbstract
{
    private List<Sprite> _spritesAudio;
    private AudioSource _audioSource;
    private Image _icon;
    private bool _isEnabled;

    public ButtonSound(Button button, List<Sprite> spritesAudio, AudioSource audioSource, Image icon) : base(button) 
    {
        _spritesAudio = spritesAudio;
        _audioSource = audioSource;
        _icon = icon;

        if(SceneData.GetAudio(out Sprite sprite, out bool isEnabled))
        {
            _isEnabled = isEnabled;
            _icon.sprite = sprite;
            _audioSource.enabled = !_isEnabled;
        }
    }

    protected override void OnButtonClick()
    {
        _isEnabled = Convert.ToBoolean(_spritesAudio.IndexOf(_icon.sprite));
        _audioSource.enabled = !_isEnabled;
        _icon.sprite = _isEnabled ? _spritesAudio[0] : _spritesAudio[1];

        SceneData.SetAudio(_icon.sprite, _isEnabled);
    }
}