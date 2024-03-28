using System.Collections.Generic;
using UnityEngine;

public class ListLevelsUI
{
    private LevelUISpawner _spawner;
    private List<Level> _levels = new();
    private int _maxAvailableLevel;

    public ListLevelsUI(ListLevels listLevels, LevelUISpawner spawner)
    {
        _maxAvailableLevel = new PlayerDataMaxAvailableLevel().Level;
        _levels = listLevels.Levels;
        _spawner = spawner;
    }

    public void Start()
    {
        for (int i = 0; i < _levels.Count; i++)
        {
            LevelUIPrefab levelUI = _spawner.GetLevelUI(_levels[i]);

            if (levelUI.Level.Number <= _maxAvailableLevel)
                levelUI.DisableLock();
        }
    }
}