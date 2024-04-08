using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonExit : AbstractButton
{
    private int _indexScene;

    public ButtonExit(Button button, AudioSource audioSource, int indexScene = 1) : base(button, audioSource) 
    {
        _indexScene = indexScene;
    }

    protected override void Activate()
    {
        SceneManager.LoadScene(_indexScene);
    }
}