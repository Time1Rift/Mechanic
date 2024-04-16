using TMPro;
using UnityEngine;
using DG.Tweening;

public class ConstructionView
{
    private Transform _preview;
    private TextMeshProUGUI _numberText;
    private float _durationMover;

    private Transform _transformCamera;
    private Vector3 _cameraIndentation;
    private float _moveDuration;
    private Vector3 _sesignReviewPosition;
    private Vector3 _curentPosition;
    private float _durationRotate;
    private Vector3 _centralPosition;

    public ConstructionView(Figure figure, ConstructionViewInfo _constructionViewInfo)
    {
        _preview = figure.Preview;
        _numberText = figure.NumberText;
        _centralPosition = figure.CentralPosition;
        _durationMover = _constructionViewInfo.DurationMover;
        _cameraIndentation = _constructionViewInfo.CameraIndentation;
        _moveDuration = _constructionViewInfo.MoveDuration;
        _durationRotate = _constructionViewInfo.DurationRotate;
        _sesignReviewPosition = _constructionViewInfo.SesignReviewPosition;
        _transformCamera = Camera.main.transform;
    }

    public void ShowEntireStructure(bool isWorking)
    {
        if (isWorking)
        {
            _transformCamera.DOMove(_curentPosition, _moveDuration).SetDelay(_moveDuration);
        }
        else
        {
            Vector3 position = new Vector3
                (
                _centralPosition.x,
                _centralPosition.y * _sesignReviewPosition.y,
                _centralPosition.x * _sesignReviewPosition.z
                );
            _transformCamera.DOMove(position, _moveDuration).SetDelay(_moveDuration);
        }
    }

    public void RemovePreview() => _preview.gameObject.SetActive(false);

    public void MoveCamera(Vector3 point)
    {
        point += _cameraIndentation;
        _transformCamera.DOMove(point, _moveDuration).SetDelay(_moveDuration);
        _curentPosition = point;
    }

    public void DrawPreview(Vector3 point, int number)
    {
        _preview.localPosition = point;
        _numberText.text = number.ToString();
    }

    public void DrawBolt(Transform bolt, Vector3 point)
    {
        bolt.DOLocalRotate(Vector3.zero, _durationRotate);
        bolt.DOLocalPath(new Vector3[] { point }, _durationMover, PathType.CatmullRom);
    }
}