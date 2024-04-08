public class CompositeRootPauseUI
{
    private ButtonWindowOpening _pause;
    private ButtonClose _close;
    private ButtonReboot _reboot;
    private ButtonExit _exit;

    public CompositeRootPauseUI(InfoPauseUI info)
    {
        _pause = new ButtonWindowOpening(info.ButtonPause, info.AudioSource, info.PauseScreen);
        _close = new ButtonClose(info.ButtonClose, info.AudioSource, info.PauseScreen);
        _reboot = new ButtonReboot(info.ButtonReboot, info.AudioSource);
        _exit = new ButtonExit(info.ButtonExit, info.AudioSource);
    }

    public void Enable()
    {
        _pause.Enabled();
        _close.Enabled();
        _reboot.Enabled();
        _exit.Enabled();
    }

    public void Disable()
    {
        _pause.Disable();
        _close.Disable();
        _reboot.Disable();
        _exit.Disable();
    }

    public IPressed[] Subscribe() => new IPressed[] { _pause, _close };
}