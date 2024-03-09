using TMPro;
using UnityEngine;
using DG.Tweening;

public class ConstructionView
{
    private Transform _transform;
    private TextMeshProUGUI _numberText;
    private float _durationMover;

    public ConstructionView(Transform transform, TextMeshProUGUI text, ConstructionViewInfo _constructionViewInfo)
    {
        _transform = transform;
        _numberText = text;
        _durationMover = _constructionViewInfo.DurationMover;
    }

    public void Draw(Vector3 point, int number)
    {
        _transform.position = point;
        _numberText.text = number.ToString();
    }

    public void DrawBolt(Transform bolt, Transform point)
    {
        bolt.DOPath(new Vector3[] { point.position }, _durationMover, PathType.CatmullRom);
    }
}