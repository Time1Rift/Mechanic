using UnityEngine;

public class CompositeRootLevelsUI
{
    private ButtonClose _buttonClose;
    private ButtonWindowOpening _buttonShop;
    private ListLevelsUI _listLevels;

    public CompositeRootLevelsUI(InfoLevelsUI info)
    {
        _buttonShop = new ButtonWindowOpening(info.ButtonLevels, info.AudioSource, info.LevelsScreen);
        _buttonClose = new ButtonClose(info.ButtonClose, info.AudioSource, info.LevelsScreen);
        _listLevels = new ListLevelsUI(info.ListLevels, info.Spawner);
    }

    public void Start()
    {
        _listLevels.Start();
    }

    public void Enable()
    {
        _buttonClose.Enabled();
        _buttonShop.Enabled();
    }

    public void Disable()
    {
        _buttonClose.Disable();
        _buttonShop.Disable();
    }
}