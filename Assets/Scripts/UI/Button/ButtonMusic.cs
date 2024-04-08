using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ButtonMusic : AbstractButtonAudio
{
    private const string NewNameFile = "MusicVolume";

    public ButtonMusic(Button button, AudioSource audioSource, List<GameObject> spritesAudio, AudioMixerGroup mixer, AbstractPlayerDataAudio playerData) 
        : base(button, audioSource, spritesAudio, mixer, playerData) { }

    protected override string ChangeNameFile() => NewNameFile;
}