using TMPro;
using UnityEngine;
using DG.Tweening;

public class ConstructionView
{
    private Transform _preview;
    private TextMeshProUGUI _numberText;
    private float _durationMover;

    private Transform _transformCamera;
    private Vector3 _positionIndentation;
    private float _moveDuration;
    private Vector3 _sesignReviewPosition;
    private Vector3 _curentPosition;
    private float _durationRotate;

    public ConstructionView(Transform preview, TextMeshProUGUI text, ConstructionViewInfo _constructionViewInfo)
    {
        _preview = preview;
        _numberText = text;
        _durationMover = _constructionViewInfo.DurationMover;
        _positionIndentation = _constructionViewInfo.PositionIndentation;
        _moveDuration = _constructionViewInfo.MoveDuration;
        _durationRotate = _constructionViewInfo.DurationRotate;
        _sesignReviewPosition = _constructionViewInfo.SesignReviewPosition;
        _transformCamera = Camera.main.transform;
    }

    public void ShowEntireStructure(bool isWorking)
    {
        if (isWorking)
            _transformCamera.DOMove(_curentPosition, _moveDuration).SetDelay(_moveDuration);
        else
            _transformCamera.DOMove(_sesignReviewPosition, _moveDuration).SetDelay(_moveDuration);
    }

    public void RemovePreview() => _preview.gameObject.SetActive(false);

    public void MoveCamera(Vector3 point)
    {
        point += _positionIndentation;
        _transformCamera.DOMove(point, _moveDuration).SetDelay(_moveDuration);
        _curentPosition = point;
    }

    public void DrawPreview(Vector3 point, int number)
    {
        _preview.position = point;
        _numberText.text = number.ToString();
    }

    public void DrawBolt(Transform bolt, Transform point)
    {
        bolt.DOLocalRotate(Vector3.zero, _durationRotate);
        bolt.DOPath(new Vector3[] { point.position }, _durationMover, PathType.CatmullRom);
    }
}