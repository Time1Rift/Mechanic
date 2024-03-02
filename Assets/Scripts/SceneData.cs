using UnityEngine;

public class SceneData : MonoBehaviour
{
    private static bool _isEnabled;
    private static Sprite _icon;

    public static bool GetAudio(out Sprite sprite, out bool isEnabled)
    {        
        sprite = _icon;
        isEnabled = _isEnabled;

        return _icon != null;
    }

    public static void SetAudio(Sprite sprite, bool isEnabled)
    {
        _icon = sprite;
        _isEnabled = isEnabled;
    }
}