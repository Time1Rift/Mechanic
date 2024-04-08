using System;
using UnityEngine;

public class Construction : IWin, IFigured
{
    private ConstructionView _view;
    private Detail _detail;
    private Vector3 _point;
    private int _number;
    private PartDetail _partDetail;
    private Figure _figure;

    public Construction(Figure figure, ConstructionView view)
    {
        _figure = figure;
        _view = view;
    }

    public event Action Win;
    public event Action ItemReceived;

    public void SetDetail()
    {
        _detail = _figure.GetDetail();
        SetPoint();
    }

    public void Subscribe(Bolt bolt) => bolt.Postponed += OnPostponed;

    public void Unsubscribe(Bolt bolt) => bolt.Postponed -= OnPostponed;

    private void OnPostponed(Bolt bolt)
    {
        if (bolt.Number != _number)
            return;
                
        bolt.Postponed -= OnPostponed;
        bolt.Transform.SetParent(_figure.transform);
        bolt.DisableText();
        _view.DrawBolt(bolt.Transform, _point);

        TryGetPoint();
    }

    private void TryGetPoint()
    {
        if (_detail.Count != 0)
        {
            SetPoint();
            return;
        }

        if (_figure.Count == 0)
        {
            _view.RemovePreview();
            Win?.Invoke();
        }
        else
        {
            SetDetail();
        }
    }

    private void SetPoint()
    {
        _partDetail = _detail.GetPartDetail();
        _point = _partDetail.Position;
        _number = _partDetail.Number;
        
        _view.DrawPreview(_point, _number);
        _view.MoveCamera(_point);

        ItemReceived?.Invoke();
    }
}