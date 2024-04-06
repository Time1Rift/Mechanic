using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField, Min(0f)] private float _targetValue = 1f;
    [SerializeField, Min(0f)] private float _step = 0.25f;

    private Coroutine _changeDownloadValue;

    private void Start()
    {
        _slider.value = 0;
        _changeDownloadValue = StartCoroutine(ChangeDownloadValue());
    }

    private void OnDisable()
    {
        if (_changeDownloadValue != null)
            StopCoroutine(_changeDownloadValue);
    }

    private IEnumerator ChangeDownloadValue()
    {
        while (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _step * Time.deltaTime);
            yield return null;
        }
    }
}