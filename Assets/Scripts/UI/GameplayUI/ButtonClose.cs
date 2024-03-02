using UnityEngine;
using UnityEngine.UI;

public class ButtonClose : ButtonAbstract
{
    private GameObject _windowSettings;

    public ButtonClose(Button button, GameObject windowSettings) : base(button)
    {
        _windowSettings = windowSettings;
    }
    protected override void OnButtonClick()
    {
        _windowSettings.SetActive(false);
    }
}