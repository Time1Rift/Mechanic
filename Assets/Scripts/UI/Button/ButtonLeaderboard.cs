using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLeaderboard : AbstractButton
{
    private GameObject _window;
    private YandexLeaderboard _yandexLeaderboard;

    public ButtonLeaderboard(Button button, AudioSource audioSource, YandexLeaderboard yandexLeaderboard, GameObject window) : base(button, audioSource) 
    {
        _window = window;
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
            _window.SetActive(true);
            PlayerAccount.RequestPersonalProfileDataPermission();
            _yandexLeaderboard.Fill();
        }
    }
}