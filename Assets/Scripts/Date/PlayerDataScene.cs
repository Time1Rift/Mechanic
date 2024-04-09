using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataScene : MonoBehaviour
{
    private const string NameFile = "DataScene";

    public event Action SceneLoaded;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(NameFile) == false)
            PlayerPrefs.SetInt(NameFile, SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
        if(GetValue() == 0)
            SceneLoaded?.Invoke();

        SetValue();
    }

    private int GetValue() => PlayerPrefs.GetInt(NameFile);

    private void SetValue()
    {
        PlayerPrefs.SetInt(NameFile, SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }
}