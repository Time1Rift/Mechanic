using System;
using System.Collections.Generic;
using UnityEngine;

public class Construction : IWin, IFigured
{
    private Queue<Detail> _details = new();
    private ConstructionView _view;
    private Detail _detail;
    private Transform _point;
    private int _number;
    private PartDetail _partDetail;

    public Construction(Transform model, ConstructionView view)
    {
        for (int i = 0; i < model.childCount; i++)
            _details.Enqueue(new Detail(model.GetChild(i)));

        _view = view;
    }

    public event Action Win;
    public event Action ItemReceived;

    public void SetDetail()
    {
        _detail = _details.Dequeue();
        _detail.Draw();
        SetPoint();
    }

    public void Subscribe(Bolt bolt) => bolt.Postponed += OnPostponed;

    public void Unsubscribe(Bolt bolt) => bolt.Postponed -= OnPostponed;

    private void OnPostponed(Bolt bolt)
    {
        if (bolt.Number != _number)
            return;
                
        bolt.Postponed -= OnPostponed;
        bolt.Transform.SetParent(_point);
        bolt.DisableText();
        _view.DrawBolt(bolt.Transform, _point);

        TryGetPoint();
    }

    private void TryGetPoint()
    {
        if (_detail.TryCount)
        {
            SetPoint();
            return;
        }

        if (_details.Count == 0)
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
        _point = _partDetail.Transform;
        _number = _partDetail.Number;
        
        _view.MoveCamera(_point.position);
        _view.DrawPreview(_point.position, _number);

        ItemReceived?.Invoke();
    }
}