using UnityEngine;

public class ShelfCell
{
    private Transform _transform;
    private Bolt _bolt;

    public ShelfCell(Transform transform, Bolt bolt)
    {
        _transform = transform;
        _bolt = bolt;
    }

    public bool IsCellEmpty => _bolt == null;

    public bool IsVerifyValueCells(Bolt bolt) => _bolt == bolt;

    public void DeleteBolt() => _bolt = null;

    public Vector3 GetPosition() => _transform.position;

    public void SetBolt(Bolt bolt)
    {
        _bolt = bolt;
        _bolt.Transform.SetParent(_transform);
    }
}