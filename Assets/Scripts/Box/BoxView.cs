using System.Collections.Generic;
using UnityEngine;

public class BoxView
{
    private float _offset;

    public BoxView(float offset)
    {
        _offset = offset;
    }

    public void Subscribe(Box box) => box.ListBoltsCreated += OnBoltsCreated;

    public void Unsubscribe(Box box) => box.ListBoltsCreated -= OnBoltsCreated;

    private void OnBoltsCreated(KeyValuePair<Vector3, List<Bolt>> bolts)
    {
        List<Bolt> newBolts = bolts.Value;
        Vector3 _boltOffset = Vector3.zero;

        for (int i = 0; i < newBolts.Count; i++)
        {
            newBolts[i].transform.position = bolts.Key + _boltOffset;
            _boltOffset.z -= _offset;
        }
    }
}