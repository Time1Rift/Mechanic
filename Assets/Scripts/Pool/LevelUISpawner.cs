using UnityEngine;

public class LevelUISpawner : ObjectPool<LevelUIPrefab>
{
    [SerializeField] private LevelUIPrefab _prefabe;

    private LevelUIPrefab _newPrefabe;

    public LevelUIPrefab GetLevelUI(Level level)
    {
        _newPrefabe = GetObject(_prefabe);
        _newPrefabe.gameObject.SetActive(true);
        _newPrefabe.Initialize(level);
        return _newPrefabe;
    }
}