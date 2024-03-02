using UnityEngine;

public class SpawnPoints
{
    private Transform _transform;
    private Transform[] _points;
    private float _offset;

    public SpawnPoints(Transform transform, float offset)
    {
        _offset = offset;
        _transform = transform;

        ArrangePoints();
    }

    public Transform[] GetPoints()
    {
        Transform[] result = new Transform[_points.Length];

        for (int i = 0; i < result.Length; i++)
            result[i] = _points[i];

        return result;
    }

    private void ArrangePoints()
    {
        _points = new Transform[_transform.childCount];
        Vector3 offset = new Vector3(_offset, 0, 0);

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _transform.GetChild(i);
            _points[i].position += offset;
            offset.x += _offset;
        }
    }
}