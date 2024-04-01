using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonExit : ButtonAbstract
{
    private int _indexScene;

    public ButtonExit(UnityEngine.UI.Button button, int indexScene = 1) : base(button) 
    {
        _indexScene = indexScene;
    }

    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(_indexScene);
    }
}