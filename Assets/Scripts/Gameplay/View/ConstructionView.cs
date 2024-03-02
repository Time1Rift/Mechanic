using TMPro;
using UnityEngine;

public class ConstructionView
{
    private RectTransform _rectTransform;
    private TextMeshProUGUI _numberText;

    public ConstructionView(RectTransform rectTransform, TextMeshProUGUI text)
    {
        _rectTransform = rectTransform;
        _numberText = text;
    }

    public void Draw(Vector3 point, int number)
    {
        _rectTransform.position = point;
        _numberText.text = number.ToString();
    }

    public void DrawBolt(Transform bolt, Transform point)
    {
        bolt.position = point.position;
    }
}