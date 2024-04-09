using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellShop : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _lock;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Button _selectionButton;

    private AudioSource _audioSource;

    public VarietyBolt VarietyBolt { get; private set; }

    public event Action<CellShop, VarietyBolt> SellButtonClick;
    public event Action<VarietyBolt> SelectionButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnSellButtonClick);
        _selectionButton.onClick.AddListener(OnSelectionButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
        _selectionButton.onClick.RemoveListener(OnSelectionButtonClick);
    }

    public void EnableLock()
    {
        _lock.SetActive(true);
        _selectionButton.gameObject.SetActive(false);
    }

    public void DisableLock() => _lock.SetActive(false);

    public void EnableSelectionButton()
    {
        _audioSource.Play();
        _selectionButton.gameObject.SetActive(true);
    }

    public void DisableSelectionButton()
    {
        _audioSource.Play();
        _selectionButton.gameObject.SetActive(false);
    }

    public void Render(VarietyBolt varietyBolt, AudioSource audioSource)
    {
        _audioSource = audioSource;
        VarietyBolt = varietyBolt;
        _icon.sprite = varietyBolt.Icon;
        _priceText.text = varietyBolt.Price.ToString();
    }

    private void OnSelectionButtonClick()
    {
        _selectionButton.gameObject.SetActive(false);
        SelectionButtonClick?.Invoke(VarietyBolt);
    }

    private void OnSellButtonClick()
    {
        _audioSource.Play();
        SellButtonClick?.Invoke(this, VarietyBolt);
    }
}