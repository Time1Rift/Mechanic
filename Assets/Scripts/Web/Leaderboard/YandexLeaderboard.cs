using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;

public class YandexLeaderboard : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard";
    private const string AnonymousName = "Anonymous";

    private readonly List<LeaderboardPlayer> _leaderboardPlayers = new();

    [SerializeField] private LeaderboardView _leaderboardView;
    [SerializeField, Min(0)] private int maxEntries = 10;
    [SerializeField] private LeaderboardElement _player;

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        SetPlayerScore();
#endif
    }

    public void SetPlayerScore()
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        PlayerDateCompletedLevels completedLevels = new PlayerDateCompletedLevels();
        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result == null || result.score < completedLevels.GetValue())
                Leaderboard.SetScore(LeaderboardName, completedLevels.GetValue());
            else if (result.score > completedLevels.GetValue())
                completedLevels.SetValue(result.score);
        });
    }

    public void Fill()
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        _leaderboardPlayers.Clear();
        InitializePlayer();

        Leaderboard.GetEntries(LeaderboardName, (result) =>
        {
            int leadersNumber = result.entries.Length >= maxEntries ? maxEntries : result.entries.Length;

            for (int i = 0; i < leadersNumber; i++)
            {
                int rank = result.entries[i].rank;
                int score = result.entries[i].score;
                string name = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = AnonymousName;

                _leaderboardPlayers.Add(new LeaderboardPlayer(rank, name, score));
            }

            _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
        });
    }

    private void InitializePlayer()
    {
        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            string name = result.player.publicName;

            if (string.IsNullOrEmpty(name))
                name = AnonymousName;

            _player.Initialize(name, result.rank, result.score);
        });
    }
}