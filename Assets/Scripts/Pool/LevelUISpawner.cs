using UnityEngine;

public class LevelUISpawner : ObjectPool<LevelUIPrefab>
{
    [SerializeField] private LevelUIPrefab _prefabe;
    [SerializeField] private AudioSource _audioSource;

    private LevelUIPrefab _newPrefabe;

    public LevelUIPrefab GetLevelUI(Level level)
    {
        _newPrefabe = GetObject(_prefabe);
        _newPrefabe.gameObject.SetActive(true);
        _newPrefabe.Initialize(level, _audioSource);
        return _newPrefabe;
    }
}