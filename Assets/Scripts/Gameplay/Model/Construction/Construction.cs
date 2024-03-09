using System;
using System.Collections.Generic;
using UnityEngine;

public class Construction : IWin
{
    private Queue<Detail> _details = new();
    private ConstructionView _view;
    private Detail _detail;
    private Transform _point;
    private int _number;

    public Construction(Transform model, ConstructionView view)
    {
        for (int i = 0; i < model.childCount; i++)
            _details.Enqueue(new Detail(model.GetChild(i)));

        _view = view;
    }

    public event Action Win;

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
        bolt.Postponed -= OnPostponed;

        if (bolt.Number != _number)
            return;
        
        Transform transform = bolt.transform;
        transform.SetParent(_point);
        bolt.DisableText();
        _view.DrawBolt(transform, _point);

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
            Win?.Invoke();
        else
            SetDetail();
    }

    private void SetPoint()
    {
        _point = _detail.GetPoint();
        _number = _detail.Number;

        _view.Draw(_point.position, _number);
    }
}