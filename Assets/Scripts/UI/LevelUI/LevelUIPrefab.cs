using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIPrefab : MonoBehaviour
{
    [SerializeField] private GameObject _Lock;
    [SerializeField] private TextMeshProUGUI _numberLevel;
    [SerializeField] private Button _buttonPlay;

    private ButtonPlay _play;

    public Level Level { get; private set; }

    private void OnEnable()
    {
        _play.Enabled();
    }

    private void OnDisable()
    {
        _play.Disable();
    }

    public void Initialize(Level level)
    {
        _play = new ButtonPlay(_buttonPlay, level.Number);
        Level = level;
        _numberLevel.text = level.Number.ToString();
    }

    public void DisableLock() => _Lock.SetActive(false);
}