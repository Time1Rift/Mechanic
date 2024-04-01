using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataScene : MonoBehaviour
{
    private const string DataScene = "DataScene";

    public event Action SceneLoaded;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(DataScene) == false)
            PlayerPrefs.SetInt(DataScene, SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
        if(GetValue() == 0)
            SceneLoaded?.Invoke();

        SetValue();
    }

    private int GetValue() => PlayerPrefs.GetInt(DataScene);

    private void SetValue() => PlayerPrefs.SetInt(DataScene, SceneManager.GetActiveScene().buildIndex);
}