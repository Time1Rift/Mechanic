using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCleaningShelfVideoAd : AbstractButton, IPressed, IShelfCleared
{
    private GameObject _window;
    private VideoAd _videoAd;

    public ButtonCleaningShelfVideoAd(Button button, AudioSource audioSource, GameObject window) : base(button, audioSource)
    {
        _window = window;
        _videoAd = new VideoAd();
    }

    public event Action ShelfCleared;
    public event Action<bool> Pressed;

    protected override void AddEnabled() => _videoAd.AdShowed += OnAdShowed;

    protected override void AddDisable() => _videoAd.AdShowed -= OnAdShowed;

    protected override void Activate()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        _videoAd.Show();
#endif
    }

    private void OnAdShowed()
    {
        _window.SetActive(false);
        Pressed?.Invoke(true);
        ShelfCleared?.Invoke();
    }
}