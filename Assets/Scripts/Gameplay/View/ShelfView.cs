using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using System;

public class ShelfView
{
    private float _durationMover;
    private float _durationConnected;
    private float _durationRotate;
    private float _durationScale;
    private float _maxScale;
    private float _minScale;
    private Shelf _shelf;

    private List<ShelfCell> _shelfCells = new();

    private Queue<Bolt> _boltsMover = new();
    private Queue<Bolt> _boltsConnected = new();
    private int _countduplicates;
    private Bolt _boltPulsate;


    public ShelfView(ShelfViewInfo shelfViewInfo, Transform transformShelf, Shelf shelf)
    {
        _durationMover = shelfViewInfo.DurationMover;
        _durationConnected = shelfViewInfo.DurationConnected;
        _durationRotate = shelfViewInfo.DurationRotate;
        _durationScale = shelfViewInfo.DurationScale;
        _maxScale = shelfViewInfo.MaxScale;
        _minScale = shelfViewInfo.MinScale;
        _shelf = shelf;

        SpawnPoints spawnPoints = new SpawnPoints();
        Transform[] points = spawnPoints.GetPoints(transformShelf, shelfViewInfo.Offset);

        foreach (Transform item in points)
            _shelfCells.Add(new ShelfCell(item, null));
    }

    public event Action<Bolt> Moved;
    public event Action Connected;
    public event Action<Bolt> Pulsated;

    public void MoverBolt(Bolt bolt)
    {
        AddBolt(bolt);
        _boltsMover.Enqueue(bolt);
        bolt.Transform.DOLocalPath(new Vector3[] { Vector3.zero }, _durationMover, PathType.CatmullRom).OnComplete(SendEventMoved);
    }

    public void ConnectBolts(IEnumerable<Bolt> duplicates)
    {
        _countduplicates = duplicates.Count();
        Vector3 position = duplicates.FirstOrDefault().Transform.position;

        foreach (var bolt in duplicates)
        {
            RemoveBolt(bolt);
            _boltsConnected.Enqueue(bolt);
            bolt.Transform.DOPath(new Vector3[] { position }, _durationConnected, PathType.CatmullRom).OnComplete(DisableBolt);
        }
    }

    public void Pulsate(Bolt bolt)
    {
        int modifier = 2;

        _boltPulsate = bolt;
        AddBolt(_boltPulsate);
        _boltPulsate.Transform.localPosition = Vector3.zero;
        _boltPulsate.Transform.DOScale(_maxScale, _durationScale).SetEase(Ease.Linear).SetLoops(modifier, LoopType.Yoyo);
        _boltPulsate.Transform.DOScale(_minScale, _durationScale).SetEase(Ease.Linear).SetLoops(modifier, LoopType.Yoyo).SetDelay(modifier * _durationScale)
            .OnComplete(SendEventPulsated);
    }

    public void ClearShelf()
    {
        foreach (var item in _shelfCells)
            item.DeleteBolt();
    }

    public void RemoveBolt(Bolt bolt)
    {
        foreach (var item in _shelfCells)
        {
            if (item.IsVerifyValueCells(bolt))
            {
                item.DeleteBolt();
                return;
            }
        }
    }

    private void AddBolt(Bolt bolt)
    {
        foreach (var item in _shelfCells)
        {
            if (item.IsCellEmpty)
            {
                item.SetBolt(bolt);
                bolt.Transform.DOLocalRotate(Vector3.zero, _durationRotate);
                return;
            }
        }
    }

    private void DisableBolt()
    {
        _shelf.DisableBolt(_boltsConnected.Dequeue());
        _countduplicates--;

        if (_countduplicates == 0)
            Connected?.Invoke();
    }

    private void SendEventMoved() => Moved?.Invoke(_boltsMover.Dequeue());

    private void SendEventPulsated() => Pulsated?.Invoke(_boltPulsate);
}