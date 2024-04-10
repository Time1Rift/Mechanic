using System.Collections;
using TMPro;
using UnityEngine;

public class TimerInterstitialAd : MonoBehaviour
{
    [SerializeField, Min(0)] private int _delay = 180;
    [SerializeField, Min(0f)] private float _delayWarning = 1.1f;
    [SerializeField] private GameObject _warning;
    [SerializeField] private TextMeshProUGUI _textNumber;
    [SerializeField, Min(0)] private int _counter = 3;

    private InterstitialAd _interstitialAd;
    private Coroutine _showAd;

    private void Awake()
    {
        _interstitialAd = new InterstitialAd();
        _warning.SetActive(false);
    }

    private void Start()
    {
        _showAd = StartCoroutine(ShowAd(_delay, _delayWarning));
    }

    private void OnDisable()
    {
        if (_showAd != null)
            StopCoroutine(_showAd);
    }

    private IEnumerator ShowAd(int delay, float delayWarning)
    {
        var wait = new WaitForSeconds(delay);
        var waitWarning = new WaitForSeconds(delayWarning);

        while (enabled)
        {
            yield return wait;
            _warning.SetActive(true);

            for (int i = _counter; i > 0; i--)
            {
                _textNumber.text = i.ToString();
                yield return waitWarning;
            }

#if UNITY_WEBGL && !UNITY_EDITOR
            _interstitialAd.Show();
#endif
            _warning.SetActive(false);
        }
    }
}