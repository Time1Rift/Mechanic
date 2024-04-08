using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractButton
{
    private Button _button;
    private AudioSource _audioSource;

    public AbstractButton(Button button, AudioSource audioSource)
    {
        _button = button;
        _audioSource = audioSource;
    }

    public void Enabled() => _button.onClick.AddListener(OnButtonClick);

    public void Disable() => _button.onClick.RemoveListener(OnButtonClick);

    private void OnButtonClick()
    {
        _audioSource.Play();
        Activate();
    }

    protected abstract void Activate();
}