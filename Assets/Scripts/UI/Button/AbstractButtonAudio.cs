using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public abstract class AbstractButtonAudio : AbstractButton
{
    private readonly string NameFile = "";

    private List<GameObject> _spritesAudio;
    private AudioMixerGroup _mixer;
    private bool _isEnabled = true;
    private AbstractPlayerDataAudio _playerData;
    private float _maxMusic = 0f;
    private float _minMusic = -80f;

    public AbstractButtonAudio(Button button, AudioSource audioSource, List<GameObject> spritesAudio, AudioMixerGroup mixer, AbstractPlayerDataAudio playerData) : base(button, audioSource)
    {
        NameFile = ChangeNameFile();
        _spritesAudio = spritesAudio;
        _mixer = mixer;

        _playerData = playerData;
        _isEnabled = _playerData.GetValue();

        ChangeAudio();
    }

    public void Start() => ChangeAudio();

    protected abstract string ChangeNameFile();

    protected override void Activate()
    {
        _isEnabled = !_isEnabled;
        ChangeAudio();
        _playerData.SetValue(_isEnabled);
    }

    private void ChangeAudio()
    {
        _spritesAudio[0].SetActive(!_isEnabled);
        _spritesAudio[1].SetActive(_isEnabled);

        if (_isEnabled)
            _mixer.audioMixer.SetFloat(NameFile, _maxMusic);
        else
            _mixer.audioMixer.SetFloat(NameFile, _minMusic);
    }
}