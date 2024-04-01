using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPlay : ButtonAbstract
{
    private int _indexScene;
    private int _level;
    private PlayerDataSelectedLevel _playerData;

    public ButtonPlay(Button button, int level, int indexScene = 2) : base(button) 
    {
        _indexScene = indexScene;
        _level = level;
        _playerData = new PlayerDataSelectedLevel();
    }

    protected override void OnButtonClick()
    {
        _playerData.SetValue(_level);
        SceneManager.LoadScene(_indexScene);
    }
}