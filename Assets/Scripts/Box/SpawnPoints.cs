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

    public Vector3[] GetPoints()
    {
        Vector3[] result = new Vector3[_points.Length];

        for (int i = 0; i < result.Length; i++)
            result[i] = _points[i].position;

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