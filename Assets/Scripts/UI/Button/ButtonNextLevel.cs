using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonNextLevel : AbstractButton
{
    private int _indexScene;
    private PlayerDataSelectedLevel _playerData;

    public ButtonNextLevel(Button button, AudioSource audioSource, int indexScene = 2) : base(button, audioSource) 
    {
        _indexScene = indexScene;
        _playerData = new PlayerDataSelectedLevel();
    }

    protected override void Activate()
    {
        _playerData.NextValue();
        SceneManager.LoadScene(_indexScene);
    }
}