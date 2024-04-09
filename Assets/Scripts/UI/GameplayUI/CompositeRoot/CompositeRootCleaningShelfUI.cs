public class CompositeRootCleaningShelfUI
{
    private ButtonWindowOpening _cleaningShel;
    private ButtonClose _close;
    private ButtonCleaningShelfCoins _cleaningShelfCoins;
    private ButtonCleaningShelfVideoAd _cleaningShelfVideoAd;

    private ButtonWindowOpening _wallet;
    private ButtonClose _closeWallet;

    public CompositeRootCleaningShelfUI(InfoCleaningShelfUI info)
    {
        _cleaningShel = new ButtonWindowOpening(info.ButtonCleaningShelf,info.AudioSource, info.CleaningShelfScreen);
        _close = new ButtonClose(info.ButtonClose, info.AudioSource, info.CleaningShelfScreen);
        _cleaningShelfCoins = new ButtonCleaningShelfCoins(info.ButtonCoins, info.AudioSource, info.CleaningShelfScreen);
        _cleaningShelfVideoAd = new ButtonCleaningShelfVideoAd(info.ButtonCleaningShelfVideoAd, info.AudioSource, info.CleaningShelfScreen);

        _wallet = new ButtonWindowOpening(info.ButtonCleaningShelf, info.AudioSource, info.WalletScreen);
        _closeWallet = new ButtonClose(info.ButtonClose, info.AudioSource, info.WalletScreen);
    }

    public void Enable()
    {
        _cleaningShel.Enabled();
        _close.Enabled();
        _cleaningShelfCoins.Enabled();
        _cleaningShelfVideoAd.Enabled();
        _wallet.Enabled();
        _closeWallet.Enabled();
    }

    public void Disable()
    {
        _cleaningShel.Disable();
        _close.Disable();
        _cleaningShelfCoins.Disable();
        _cleaningShelfVideoAd.Disable();
        _wallet.Disable();
        _closeWallet.Disable();
    }

    public IShelfCleared[] ClearShelf() => new IShelfCleared[] { _cleaningShelfCoins, _cleaningShelfVideoAd };

    public IButtonCleaningShelfCoins Pay() => _cleaningShelfCoins;

    public IPressed[] Subscribe() => new IPressed[] { _cleaningShel, _close, _cleaningShelfCoins, _wallet, _closeWallet, _cleaningShelfVideoAd };
}