public class CompositeRootSettingsUI
{
    private ButtonSettings _settings;
    private ButtonClose _close;
    private ButtonReboot _reboot;
    private ButtonExit _exit;
    private ButtonSound _sound;

    public CompositeRootSettingsUI(InfoSettingsUI infoSettingsUI)
    {
        _settings = new ButtonSettings(infoSettingsUI.ButtonSettings, infoSettingsUI.SettingsScreen);
        _close = new ButtonClose(infoSettingsUI.ButtonClose, infoSettingsUI.SettingsScreen);
        _reboot = new ButtonReboot(infoSettingsUI.ButtonReboot, infoSettingsUI.SettingsScreen);
        _sound = new ButtonSound(infoSettingsUI.ButtonSound, infoSettingsUI.SpritesAudio, infoSettingsUI.AudioSource, infoSettingsUI.ButtonIconSound);
        _exit = new ButtonExit(infoSettingsUI.ButtonExit);
    }

    public ButtonReboot Reboot => _reboot;

    public void Enable()
    {
        _settings.Enabled();
        _close.Enabled();
        _reboot.Enabled();
        _sound.Enabled();
        _exit.Enabled();
    }

    public void Disable()
    {
        _settings.Disable();
        _close.Disable();
        _reboot.Disable();
        _sound.Disable();
        _exit.Disable();
    }

    public IPressed[] Subscribe() => new IPressed[] { _settings, _close, _reboot };
}