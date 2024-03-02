using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompositeRootMenuUI : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private List<Sprite> _spritesAudio;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image _audioIcon;

    [Header("Button")]
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private Button _buttonSound;

    private ButtonPlay _play;
    private ButtonSound _sound;

    private void Awake()
    {
        _play = new ButtonPlay(_buttonPlay);
        _sound = new ButtonSound(_buttonSound, _spritesAudio, _audioSource, _audioIcon);
    }

    private void OnEnable()
    {
        _play.Enabled();
        _sound.Enabled();
    }

    private void OnDisable()
    {
        _play.Disable();
        _sound.Disable();
    }
}