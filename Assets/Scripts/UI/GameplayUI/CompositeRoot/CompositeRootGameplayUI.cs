using System.Linq;
using UnityEngine;

public class CompositeRootGameplayUI : MonoBehaviour
{
    [SerializeField] private InfoPauseUI _infoPauseUI;
    [SerializeField] private InfoEndGameUI _infoEndGameUI;
    [SerializeField] private InfoSettings _infoSettingsUI;
    [SerializeField] private InfoCleaningShelfUI _infoCleaningShelfUI;

    private CompositeRootPauseUI _pauseUI;
    private CompositeRootEndGameUI _endGameUI;
    private CompositeRootSettingsUI _settingsUI;
    private CompositeRootCleaningShelfUI _cleaningShelfUI;

    public void Initialize()
    {
        _pauseUI = new CompositeRootPauseUI(_infoPauseUI);
        _endGameUI = new CompositeRootEndGameUI(_infoEndGameUI);
        _settingsUI = new CompositeRootSettingsUI(_infoSettingsUI);
        _cleaningShelfUI = new CompositeRootCleaningShelfUI(_infoCleaningShelfUI);
    }

    public void Start()
    {
        _settingsUI.Start();
    }

    public void Enable()
    {
        _pauseUI.Enable();
        _endGameUI.Enable();
        _settingsUI.Enable();
        _cleaningShelfUI.Enable();
    }

    public void Disable()
    {
        _pauseUI.Disable();
        _endGameUI.Disable();
        _settingsUI.Disable();
        _cleaningShelfUI.Disable();
    }

    public IPressed[] Subscribe() => _settingsUI.Subscribe().Concat(_pauseUI.Subscribe()).Concat(_cleaningShelfUI.Subscribe()).ToArray();

    public IShelfCleared[] ClearShelf() => _cleaningShelfUI.ClearShelf();

    public IButtonCleaningShelfCoins Pay() => _cleaningShelfUI.Pay();

    public void Win() => _endGameUI.Win();

    public void Lose() => _endGameUI.Lose();
}