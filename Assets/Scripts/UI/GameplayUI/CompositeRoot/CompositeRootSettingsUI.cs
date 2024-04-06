public class CompositeRootSettingsUI
{
    private ButtonWindowOpening _settings;
    private ButtonClose _close;
    private ButtonMusic _music;
    private DropdownLocalization _localization;

    public CompositeRootSettingsUI(InfoSettings info)
    {
        _settings = new ButtonWindowOpening(info.ButtonSettings, info.SettingsScreen);
        _close = new ButtonClose(info.ButtonClose, info.SettingsScreen);
        _music = new ButtonMusic(info.ButtonMusic, info.SpritesAudio, info.AudioSource);
        _localization = new DropdownLocalization(info.Dropdown, info.Localization);
    }

    public void Enable()
    {
        _settings.Enabled();
        _close.Enabled();
        _music.Enabled();
    }

    public void Disable()
    {
        _settings.Disable();
        _close.Disable();
        _music.Disable();
    }

    public IPressed[] Subscribe() => new IPressed[] { _settings, _close };
}
