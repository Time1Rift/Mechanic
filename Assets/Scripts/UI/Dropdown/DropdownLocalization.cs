using TMPro;

public class DropdownLocalization
{
    private TMP_Dropdown _dropdown;
    private Localization _localization;

    public DropdownLocalization(TMP_Dropdown dropdown, Localization localization)
    {
        _dropdown = dropdown;
        _localization = localization;

        _dropdown.onValueChanged.AddListener(delegate { ChangeLanguage(); });
        _dropdown.value = _localization.GetCurrentLanguage();
    }

    private void ChangeLanguage() => _localization.ChangeLanguage(_dropdown.value);
}