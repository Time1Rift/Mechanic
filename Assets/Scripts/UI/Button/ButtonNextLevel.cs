using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonNextLevel : ButtonAbstract
{
    private int _indexScene;
    private PlayerDataSelectedLevel _playerData;

    public ButtonNextLevel(Button button, int indexScene = 1) : base(button) 
    {
        _indexScene = indexScene;
        _playerData = new PlayerDataSelectedLevel();
    }

    protected override void OnButtonClick()
    {
        _playerData.Level++;
        SceneManager.LoadScene(_indexScene);
    }
}