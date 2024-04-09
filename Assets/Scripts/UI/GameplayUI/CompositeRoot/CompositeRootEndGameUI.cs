using UnityEngine;

public class CompositeRootEndGameUI
{
    private GameObject _victoryScreen;
    private GameObject _gameOverScreen;     
    private ButtonNextLevel _nextLevel;
    private ButtonExit _exitWin;
    private ButtonReboot _reboot;
    private ButtonExit _exitLose;
    private AudioSource _winSound;
    private AudioSource _loseSound;

    public CompositeRootEndGameUI(InfoEndGameUI info)
    {
        _victoryScreen = info.VictoryScreen;
        _gameOverScreen = info.GameOverScreen;
        _winSound = info.WinSound;
        _loseSound = info.LoseSound;

        _nextLevel = new ButtonNextLevel(info.ButtonNextLevel, info.ButtonSound);
        _exitWin = new ButtonExit(info.ButtonExitWin, info.ButtonSound);
        _reboot = new ButtonReboot(info.ButtonReboot, info.ButtonSound);
        _exitLose = new ButtonExit(info.ButtonExitLose, info.ButtonSound);

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

    public void Win()
    {
        _winSound.Play();
        _victoryScreen.SetActive(true);
    }

    public void Lose()
    {
        _loseSound.Play();
        _gameOverScreen.SetActive(true);
    }
}