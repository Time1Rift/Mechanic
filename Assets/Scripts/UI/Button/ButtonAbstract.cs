using UnityEngine.UI;

public abstract class ButtonAbstract
{
    private Button _button;

    public ButtonAbstract(Button button)
    {
        _button = button;
    }

    public void Enabled() => _button.onClick.AddListener(OnButtonClick);

    public void Disable() => _button.onClick.RemoveListener(OnButtonClick);

    protected abstract void OnButtonClick();
}