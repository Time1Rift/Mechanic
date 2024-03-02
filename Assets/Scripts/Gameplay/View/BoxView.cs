using System.Collections.Generic;
using UnityEngine;

public class BoxView
{
    private float _offset;

    public BoxView(float offset)
    {
        _offset = offset;
    }

    public void Subscribe(IBoltsDrawed box) => box.BoltsDrawed += OnBoltsDrawed;

    public void Unsubscribe(IBoltsDrawed box) => box.BoltsDrawed -= OnBoltsDrawed;

    private void OnBoltsDrawed(BoltColumn boltColumn)
    {
        List<Transform> transforms = boltColumn.GetPositionBolts();
        Vector3 _boltOffset = Vector3.zero;

        for (int i = transforms.Count - 1; i >= 0; i--)
        {
            transforms[i].position = boltColumn.Position + _boltOffset;
            _boltOffset.z -= _offset;
        }
    }
}