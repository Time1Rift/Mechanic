public class CompositeRootLeaderboard
{
    private ButtonClose _buttonClose;
    private ButtonLeaderboard _buttonLeaderboard;

    public CompositeRootLeaderboard(InfoLeaderboard info)
    {
        _buttonClose = new ButtonClose(info.ButtonClose, info.AudioSource, info.LeaderboardScreen);
        _buttonLeaderboard = new ButtonLeaderboard(info.ButtonLeaderboard, info.AudioSource, info.YandexLeaderboard, info.LeaderboardScreen);
    }

    public void Enable()
    {
        _buttonClose.Enabled();
        _buttonLeaderboard.Enabled();
    }

    public void Disable()
    {
        _buttonClose.Disable();
        _buttonLeaderboard.Disable();
    }
}