public class CompositeRootCleaningShelfUI
{
    private ButtonWindowOpening _cleaningShel;
    private ButtonClose _close;
    private ButtonCleaningShelfCoins _cleaningShelfCoins;

    public CompositeRootCleaningShelfUI(InfoCleaningShelfUI info)
    {
        _cleaningShel = new ButtonWindowOpening(info.ButtonCleaningShelf, info.CleaningShelfScreen);
        _close = new ButtonClose(info.ButtonClose, info.CleaningShelfScreen);
        _cleaningShelfCoins = new ButtonCleaningShelfCoins(info.ButtonCoins, info.CleaningShelfScreen);
    }

    public void Enable()
    {
        _cleaningShel.Enabled();
        _close.Enabled();
        _cleaningShelfCoins.Enabled();
    }

    public void Disable()
    {
        _cleaningShel.Disable();
        _close.Disable();
        _cleaningShelfCoins.Disable();
    }

    public IShelfCleared ClearShelf() => _cleaningShelfCoins;

    public IButtonCleaningShelfCoins Pay() => _cleaningShelfCoins;

    public IPressed[] Subscribe() => new IPressed[] { _cleaningShel, _close, _cleaningShelfCoins };
}