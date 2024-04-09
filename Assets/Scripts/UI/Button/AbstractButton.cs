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

    public void Enabled()
    {
        _button.onClick.AddListener(OnButtonClick);
        AddEnabled();
    }

    public void Disable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
        AddDisable();
    }

    private void OnButtonClick()
    {
        if (_audioSource != null)
            _audioSource.Play();

        Activate();
    }

    protected virtual void AddEnabled() { }

    protected virtual void AddDisable() { }

    protected abstract void Activate();
}