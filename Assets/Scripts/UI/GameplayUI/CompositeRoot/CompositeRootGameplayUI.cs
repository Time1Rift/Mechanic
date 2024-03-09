using System.Linq;
using UnityEngine;

public class CompositeRootGameplayUI : MonoBehaviour
{
    [SerializeField] private InfoSettingsUI _infoSettingsUI;
    [SerializeField] private InfoEndGameUI _infoEndGameUI;

    private CompositeRootSettingsUI _settingsUI;
    private CompositeRootEndGameUI _endGameUI;

    public void Initialize()
    {
        _settingsUI = new CompositeRootSettingsUI(_infoSettingsUI);
        _endGameUI = new CompositeRootEndGameUI(_infoEndGameUI);
    }

    public void Enable()
    {
        _settingsUI.Enable();
        _endGameUI.Enable();
    }

    public void Disable()
    {
        _settingsUI.Disable();
        _endGameUI.Disable();
    }

    public IPressed[] Subscribe() => _endGameUI.Subscribe().Concat(_settingsUI.Subscribe()).ToArray();

    public ButtonReboot[] GetButtonReboots() => new ButtonReboot[] { _settingsUI.Reboot, _endGameUI.Reboot };

    public void Win() => _endGameUI.Win();

    public void Lose() => _endGameUI.Lose();
}