using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPlay : ButtonAbstract
{
    private int _indexScene;

    public ButtonPlay(Button button, int indexScene = 1) : base(button) 
    {
        _indexScene = indexScene;
    }

    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(_indexScene);
    }
}