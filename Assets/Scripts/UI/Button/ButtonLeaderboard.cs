using Agava.YandexGames;
using UnityEngine.UI;

public class ButtonLeaderboard : ButtonAbstract
{
    private YandexLeaderboard _yandexLeaderboard;

    public ButtonLeaderboard(Button button, YandexLeaderboard yandexLeaderboard) : base(button) 
    {
        _yandexLeaderboard = yandexLeaderboard;
    }

    protected override void OnButtonClick()
    {
        OpenLeaderboard();
    }

    private void OpenLeaderboard()
    {
        PlayerAccount.Authorize();

        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
            _yandexLeaderboard.Fill();
        }
    }
}