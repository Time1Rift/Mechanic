using System.Collections.Generic;
using UnityEngine;

public class Detail
{
    private Queue<PartDetail> _partDetails = new();

    public int Count => _partDetails.Count;

    public void AddPartDetail(int number, Vector3 position) => _partDetails.Enqueue(new PartDetail(number, position));

    public PartDetail GetPartDetail() => _partDetails.Dequeue();
}