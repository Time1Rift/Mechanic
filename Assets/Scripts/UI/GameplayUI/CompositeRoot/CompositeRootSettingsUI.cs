public class CompositeRootSettingsUI
{
    private ButtonWindowOpening _settings;
    private ButtonClose _close;
    private ButtonMusic _music;

    public CompositeRootSettingsUI(InfoSettings info)
    {
        _settings = new ButtonWindowOpening(info.ButtonSettings, info.SettingsScreen);
        _close = new ButtonClose(info.ButtonClose, info.SettingsScreen);
        _music = new ButtonMusic(info.ButtonMusic, info.SpritesAudio, info.AudioSource, info.ButtonIconSound);
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
