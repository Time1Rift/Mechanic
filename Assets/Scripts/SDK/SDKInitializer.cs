using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SDKInitializer : MonoBehaviour
{
    private const int Menu = 1;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
            yield return YandexGamesSdk.Initialize(OnInitialize);
    }

    private void OnInitialize() => SceneManager.LoadScene(Menu);
}