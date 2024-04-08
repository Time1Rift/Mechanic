using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonPlay : AbstractButton
{
    private int _indexScene;
    private int _level;
    private PlayerDataSelectedLevel _playerData;

    public ButtonPlay(Button button, AudioSource audioSource, int level, int indexScene = 2) : base(button, audioSource) 
    {
        _indexScene = indexScene;
        _level = level;
        _playerData = new PlayerDataSelectedLevel();
    }

    protected override void Activate()
    {
        _playerData.SetValue(_level);
        SceneManager.LoadScene(_indexScene);
    }
}