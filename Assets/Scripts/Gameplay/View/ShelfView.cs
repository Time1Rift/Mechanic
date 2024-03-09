using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using System;

public class ShelfView
{
    private float _offset;
    private Vector3 _offsetBolt;
    private Transform _transform;
    private Dictionary<Vector3, Bolt> _points = new();
    private float _durationMover;
    private float _durationConnected;
    private float _durationScale;
    private float _maxScale;
    private float _minScale;
    private int _maxPoints;
    private Shelf _shelf;

    private List<Bolt> _boltsMover = new();
    private List<float> _timersMove = new();

    private float _timerConnectBolts;
    private IEnumerable<Bolt> _boltsConnected;
    private bool _isConnect = false;

    private Bolt _boltPulsate;
    private float _timerPulsate;

    public ShelfView(ShelfViewInfo shelfViewInfo, Transform transform, int maxPoints, Shelf shelf)
    {
        _offset = shelfViewInfo.Offset;
        _transform = transform;
        _durationMover = shelfViewInfo.DurationMover;
        _durationConnected = shelfViewInfo.DurationConnected;
        _durationScale = shelfViewInfo.DurationScale;
        _maxScale = shelfViewInfo.MaxScale;
        _minScale = shelfViewInfo.MinScale;
        _maxPoints = maxPoints;
        _shelf = shelf;

        CreatePoints();
    }

    public event Action Connected;
    public event Action<Bolt> Moved;
    public event Action<Bolt> Pulsated;

    public void Update(float deltaTime)
    {
        if (_boltsMover.Count > 0)
        {
            for (int i = 0; i < _boltsMover.Count; i++)
            {
                _timersMove[i] += deltaTime;

                if (_timersMove[i] >= _durationMover)
                {
                    Moved?.Invoke(_boltsMover[i]);
                    _boltsMover.Remove(_boltsMover[i]);
                    _timersMove.Remove(_timersMove[i]);
                }
            }
        }

        if (_isConnect)
        {
            _timerConnectBolts += deltaTime;

            if (_timerConnectBolts >= _durationConnected)
            {
                foreach (var bolt in _boltsConnected)
                    _shelf.DisableBolt(bolt);

                _timerConnectBolts = 0;
                _isConnect = false;
                Connected?.Invoke();
            }
        }

        if (_boltPulsate != null)
        {
            _timerPulsate -= deltaTime;

            if (_timerPulsate <= 0)
            {
                Pulsated?.Invoke(_boltPulsate);
                _boltPulsate = null;
                _timerPulsate = 0;
            }
        }
    }

    public void ClearShelf()
    {
        _points.Clear();
        CreatePoints();
    }

    public void RemoveBolt(Bolt bolt)
    {
        Vector3 point = _points.FirstOrDefault(item => item.Value == bolt).Key;
        _points[point] = null;
    }

    public float MoverBolt(Bolt bolt)
    {
        Vector3 point = AddBolt(bolt);
        bolt.transform.DOPath(new Vector3[] { point }, _durationMover, PathType.CatmullRom);

        _boltsMover.Add(bolt);
        _timersMove.Add(0f);

        return _durationMover;
    }

    public void ConnectBolts(IEnumerable<Bolt> bolts)
    {
        _boltsConnected = bolts;
        Vector3 position = _boltsConnected.FirstOrDefault().transform.position;

        foreach (var bolt in _boltsConnected) 
        {
            RemoveBolt(bolt);
            bolt.transform.DOPath(new Vector3[] { position }, _durationConnected, PathType.CatmullRom);
        }

        _isConnect = true;
    }

    public void Pulsate(Bolt bolt)
    {
        int modifier = 2;
        float errorRate = 0.1f;

        _boltPulsate = bolt;
        _timerPulsate = ((_durationScale * modifier) * modifier) + errorRate;

        Transform transform = bolt.transform;
        transform.position = AddBolt(bolt);
        transform.DOScale(_maxScale, _durationScale).SetEase(Ease.Linear).SetLoops(modifier, LoopType.Yoyo);
        transform.DOScale(_minScale, _durationScale).SetEase(Ease.Linear).SetLoops(modifier, LoopType.Yoyo).SetDelay(modifier * _durationScale);
    }

    private Vector3 AddBolt(Bolt bolt)
    {
        Vector3 point = _points.FirstOrDefault(item => item.Value == null).Key;
        _points[point] = bolt;
        return point;
    }

    private void CreatePoints()
    {
        for (int i = 0; i < _maxPoints; i++)
        {
            _offsetBolt.x = _offset * i;
            _points.Add(_transform.position + _offsetBolt, null);
        }
    }
}