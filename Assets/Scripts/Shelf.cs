using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField, Min(0)] private int _maxBolts;
    [SerializeField, Min(0f)] private float _offset = 1.1f;

    private List<Bolt> _bolts = new();
    private Vector3 _offsetBolt = Vector3.zero;

    public void SubscribeBolt(Bolt bolt) => bolt.Pressed += OnPressed;

    private void OnPressed(Bolt bolt)
    {
        bolt.Pressed -= OnPressed;

        if (_bolts.Count + 1 == _maxBolts)
            Exit();

        _bolts.Add(bolt);
        bolt.transform.SetParent(transform);
        bolt.transform.position = transform.position + _offsetBolt;
        _offsetBolt.x += _offset; 
    }

    private void Exit()
    {
        Debug.Log("Exit");
    }
}