using UnityEngine;
using UnityEngine.UI;

public class ButtonSettings : ButtonAbstract
{
    private GameObject _windowSettings;

    public ButtonSettings(Button button, GameObject windowSettings) : base(button)
    {
        _windowSettings = windowSettings;
        _windowSettings.SetActive(false);
    }

    protected override void OnButtonClick()
    {
        _windowSettings.SetActive(true);
    }
}