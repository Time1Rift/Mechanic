using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoltsDescent))]
public class BoxView : MonoBehaviour
{
    [SerializeField, Min(0f)] private readonly float _offset = 1f;

    private BoltsDescent _boltsDescent;

    private void Awake()
    {
        _boltsDescent = GetComponent<BoltsDescent>();
    }

    private void OnEnable()
    {
        _boltsDescent.BoltsCreated += OnBoltsCreated;
    }

    private void OnDisable()
    {
        _boltsDescent.BoltsCreated -= OnBoltsCreated;
    }

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