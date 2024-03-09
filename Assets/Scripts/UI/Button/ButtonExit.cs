using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonExit : ButtonAbstract
{
    private int _indexScene;

    public ButtonExit(Button button, int indexScene = 0) : base(button) 
    {
        _indexScene = indexScene;
    }

    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(_indexScene);
    }
}