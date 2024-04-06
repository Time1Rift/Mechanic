using Agava.YandexGames;
using UnityEngine;

public class SDKGameReady : MonoBehaviour
{
    [SerializeField] private PlayerDataScene _playerData;

    private void OnEnable()
    {
        _playerData.SceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        _playerData.SceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded()
    {
#if !UNITY_EDITOR
        YandexGamesSdk.GameReady();
#endif
    }
}