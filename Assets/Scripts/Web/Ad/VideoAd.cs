using System;
using UnityEngine;

public class VideoAd
{
    public event Action AdShowed;

    public void Show() => Agava.YandexGames.VideoAd.Show(OnOpenCallback, OnRewardCallback, OnCloseCallback);

    private void OnOpenCallback()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0f;
    }

    private void OnRewardCallback() => AdShowed?.Invoke();

    private void OnCloseCallback()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1f;
    }
}