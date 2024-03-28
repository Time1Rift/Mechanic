using UnityEngine;

public class CompositeRootEndGameUI
{
    private GameObject _victoryScreen;
    private GameObject _gameOverScreen;
     
    private ButtonNextLevel _nextLevel;
    private ButtonExit _exitWin;
    private ButtonReboot _reboot;
    private ButtonExit _exitLose;

    public CompositeRootEndGameUI(InfoEndGameUI infoEndGameUI)
    {
        _victoryScreen = infoEndGameUI.VictoryScreen;
        _gameOverScreen = infoEndGameUI.GameOverScreen;

        _nextLevel = new ButtonNextLevel(infoEndGameUI.ButtonNextLevel);
        _exitWin = new ButtonExit(infoEndGameUI.ButtonExitWin);
        _reboot = new ButtonReboot(infoEndGameUI.ButtonReboot);
        _exitLose = new ButtonExit(infoEndGameUI.ButtonExitLose);

        _victoryScreen.SetActive(false);
        _gameOverScreen.SetActive(false);
    }

    public void Enable()
    {
        _nextLevel.Enabled();
        _exitWin.Enabled();
        _reboot.Enabled();
        _exitLose.Enabled();
    }

    public void Disable()
    {
        _nextLevel.Disable();
        _exitWin.Disable();
        _reboot.Disable();
        _exitLose.Disable();
    }

    public void Win() => _victoryScreen.SetActive(true);

    public void Lose() => _gameOverScreen.SetActive(true);
}