using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLeaderboard : AbstractButton
{
    private YandexLeaderboard _yandexLeaderboard;

    public ButtonLeaderboard(Button button, AudioSource audioSource, YandexLeaderboard yandexLeaderboard) : base(button, audioSource) 
    {
        _yandexLeaderboard = yandexLeaderboard;
    }

    protected override void Activate()
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