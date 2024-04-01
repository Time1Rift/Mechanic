using Agava.YandexGames;
using UnityEngine;
using Lean.Localization;

public class Localization : MonoBehaviour
{
    private const string RussianCode = "Russian";
    private const string EnglishCode = "English";
    private const string TurkishCode = "Turkish";
    private const string Russian = "ru";
    private const string English = "en";
    private const string Turkish = "tr";
    private const int RussianInt = 0;
    private const int EnglishInt = 1;
    private const int TurkishInt = 2;

    [SerializeField] private LeanLocalization _leanLanguage;

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
    ChangeLanguage();
#endif
    }

    public int GetCurrentLanguage()
    {
        int number = 0;

        switch (_leanLanguage.CurrentLanguage)
        {
            case RussianCode:
                number = RussianInt;
                break;
            case EnglishCode:
                number = EnglishInt;
                break;
            case TurkishCode:
                number = TurkishInt;
                break;
        }

        return number;
    }

    public void ChangeLanguage(int value)
    {        
        switch (value)
        {
            case RussianInt:
                _leanLanguage.SetCurrentLanguage(RussianCode);
                break;
            case EnglishInt:
                _leanLanguage.SetCurrentLanguage(EnglishCode);
                break;
            case TurkishInt:
                _leanLanguage.SetCurrentLanguage(TurkishCode);
                break;
        }
    }

    private void ChangeLanguage()
    {
        string languageCode = YandexGamesSdk.Environment.i18n.lang;

        switch (languageCode)
        {
            case English:
                _leanLanguage.SetCurrentLanguage(EnglishCode);
                break;
            case Turkish:
                _leanLanguage.SetCurrentLanguage(TurkishCode);
                break;
            case Russian:
                _leanLanguage.SetCurrentLanguage(RussianCode);
                break;
        }
    }
}