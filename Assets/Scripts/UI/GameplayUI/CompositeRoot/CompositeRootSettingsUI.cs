public class CompositeRootSettingsUI
{
    private ButtonWindowOpening _settings;
    private ButtonClose _close;
    private ButtonMusic _music;
    private ButtonEffectSound _sound;

    public CompositeRootSettingsUI(InfoSettings info)
    {
        _settings = new ButtonWindowOpening(info.ButtonSettings, info.ButtonSound, info.SettingsScreen);
        _close = new ButtonClose(info.ButtonClose, info.ButtonSound, info.SettingsScreen);
        _music = new ButtonMusic(info.ButtonMusic, info.ButtonSound, info.SpritesMusic, info.Mixer, new PlayerDataMusic());
        _sound = new ButtonEffectSound(info.ButtonEffectSound, info.ButtonSound, info.SpritesEffectSound, info.Mixer, new PlayerDataEffectSound());
    }

    public void Start()
    {
        _music.Start();
        _sound.Start();
    }

    public void Enable()
    {
        _settings.Enabled();
        _close.Enabled();
        _music.Enabled();
        _sound.Enabled();
    }

    public void Disable()
    {
        _settings.Disable();
        _close.Disable();
        _music.Disable();
        _sound.Disable();
    }

    public IPressed[] Subscribe() => new IPressed[] { _settings, _close };
}
