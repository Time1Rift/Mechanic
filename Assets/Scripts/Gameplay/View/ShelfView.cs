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
    private AudioSource _effectSoundCub;
    private AudioSource _folding;

    public ShelfView(ShelfViewInfo shelfViewInfo, Transform transformShelf, Shelf shelf, AudioSource effectSoundCub, AudioSource folding)
    {
        _durationMover = shelfViewInfo.DurationMover;
        _durationConnected = shelfViewInfo.DurationConnected;
        _durationRotate = shelfViewInfo.DurationRotate;
        _durationScale = shelfViewInfo.DurationScale;
        _maxScale = shelfViewInfo.MaxScale;
        _minScale = shelfViewInfo.MinScale;
        _shelf = shelf;
        _effectSoundCub = effectSoundCub;
        _folding = folding;

        SpawnPoints spawnPoints = new SpawnPoints();
        Transform[] points = spawnPoints.GetPoints(transformShelf, shelfViewInfo.Offset);

        foreach (Transform item in points)
            _shelfCells.Add(new ShelfCell(item, null));
    }

    public event Action Moved;
    public event Action Connected;
    public event Action Pulsated;

    public void MoverBolt(Bolt bolt)
    {
        _effectSoundCub.Play();
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

        AddBolt(bolt);
        bolt.Transform.localPosition = Vector3.zero;
        bolt.Transform.DOScale(_maxScale, _durationScale).SetEase(Ease.Linear).SetLoops(modifier, LoopType.Yoyo);
        bolt.Transform.DOScale(_minScale, _durationScale).SetEase(Ease.Linear).SetLoops(modifier, LoopType.Yoyo).SetDelay(modifier * _durationScale)
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
        {
            Connected?.Invoke();
            _folding.Play();
        }
    }

    private void SendEventMoved() => Moved?.Invoke();

    private void SendEventPulsated() => Pulsated?.Invoke();
}