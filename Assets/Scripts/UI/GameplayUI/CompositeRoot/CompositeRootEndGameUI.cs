using UnityEngine;

public class CompositeRootEndGameUI
{
    private GameObject _victoryScreen;
    private GameObject _gameOverScreen;

    private ButtonPlay _play;
    private ButtonExit _exitWin;
    private ButtonReboot _reboot;
    private ButtonExit _exitLose;

    public CompositeRootEndGameUI(InfoEndGameUI infoEndGameUI)
    {
        _victoryScreen = infoEndGameUI.VictoryScreen;
        _gameOverScreen = infoEndGameUI.GameOverScreen;

        _play = new ButtonPlay(infoEndGameUI.ButtonPlay);
        _exitWin = new ButtonExit(infoEndGameUI.ButtonExitWin);
        _reboot = new ButtonReboot(infoEndGameUI.ButtonReboot, _gameOverScreen);
        _exitLose = new ButtonExit(infoEndGameUI.ButtonExitLose);

        _victoryScreen.SetActive(false);
        _gameOverScreen.SetActive(false);
    }

    public ButtonReboot Reboot => _reboot;

    public void Enable()
    {
        _play.Enabled();
        _exitWin.Enabled();
        _reboot.Enabled();
        _exitLose.Enabled();
    }

    public void Disable()
    {
        _play.Disable();
        _exitWin.Disable();
        _reboot.Disable();
        _exitLose.Disable();
    }

    public IPressed[] Subscribe() => new IPressed[] { _reboot };

    public void Win() => _victoryScreen.SetActive(true);

    public void Lose() => _gameOverScreen.SetActive(true);
}