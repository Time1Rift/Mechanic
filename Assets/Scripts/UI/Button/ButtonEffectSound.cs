using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ButtonEffectSound : AbstractButtonAudio
{
    private const string NewNameFile = "EffectVolume";

    public ButtonEffectSound(Button button, AudioSource audioSource, List<GameObject> spritesAudio, AudioMixerGroup mixer, AbstractPlayerDataAudio playerData) : base(button, audioSource, spritesAudio, mixer, playerData) { }

    protected override string ChangeNameFile() => NewNameFile;
}