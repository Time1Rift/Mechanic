using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ActiveCube : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _lock;

    private Button _button;

    public VarietyBolt VarietyBolt { get; private set; }

    public event Action<ActiveCube> Presed;

    private void Awake()
    {
        _button = GetComponent<Button>();
        EnableLock();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void Render(VarietyBolt varietyBolt)
    {
        VarietyBolt = varietyBolt;
        _icon.sprite = varietyBolt.Icon;
    }

    public void EnableLock() => _lock.SetActive(true);

    public void DisableLock() => _lock.SetActive(false);

    private void OnButtonClick()
    {
        DisableLock();
        Presed?.Invoke(this);
    }
}