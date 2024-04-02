using System.Collections.Generic;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private LeaderboardElement _leaderboardElementPrefab;

    private List<LeaderboardElement> _spawnedElements = new();

    private void Start()
    {
        LeaderboardElement leaderboardElement;

        for (int i = 0; i < _container.childCount; i++)
        {
            leaderboardElement = _container.GetChild(i).GetComponent<LeaderboardElement>();
            leaderboardElement.gameObject.SetActive(false);
            _spawnedElements.Add(leaderboardElement);
        }
    }

    public void ConstructLeaderboard(List<LeaderboardPlayer> leaderboardPlayers)
    {
        ClearLeaderboard();

        int count = Mathf.Clamp(leaderboardPlayers.Count, leaderboardPlayers.Count, _spawnedElements.Count);
        LeaderboardPlayer player;

        for (int i = 0; i < count; i++)
        {
            player = leaderboardPlayers[i];
            _spawnedElements[i].gameObject.SetActive(true);
            _spawnedElements[i].Initialize(player.Name, player.Rank, player.Score);
        }
    }

    private void ClearLeaderboard()
    {
        foreach (var element in _spawnedElements)
            element.gameObject.SetActive(false);
    }
}