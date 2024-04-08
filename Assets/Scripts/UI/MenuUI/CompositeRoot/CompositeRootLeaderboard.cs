public class CompositeRootLeaderboard
{
    private ButtonWindowOpening _buttonWindowOpening;
    private ButtonClose _buttonClose;
    private ButtonLeaderboard _buttonLeaderboard;

    public CompositeRootLeaderboard(InfoLeaderboard info)
    {
        _buttonWindowOpening = new ButtonWindowOpening(info.ButtonLeaderboard, info.AudioSource, info.LeaderboardScreen);
        _buttonClose = new ButtonClose(info.ButtonClose, info.AudioSource, info.LeaderboardScreen);
        _buttonLeaderboard = new ButtonLeaderboard(info.ButtonLeaderboard, info.AudioSource, info.YandexLeaderboard);
    }

    public void Enable()
    {
        _buttonWindowOpening.Enabled();
        _buttonClose.Enabled();
        _buttonLeaderboard.Enabled();
    }

    public void Disable()
    {
        _buttonWindowOpening.Disable();
        _buttonClose.Disable();
        _buttonLeaderboard.Disable();
    }
}