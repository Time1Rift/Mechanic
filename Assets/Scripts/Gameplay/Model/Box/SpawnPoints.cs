using UnityEngine;

public class SpawnPoints
{
    public Transform[] GetPoints(Transform transform, float offsetX)
    {
        Transform[] points = new Transform[transform.childCount];
        Vector3 offset = new Vector3(offsetX, 0, 0);

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
            points[i].position += offset;
            offset.x += offsetX;
        }

        Transform[] result = new Transform[points.Length];

        for (int i = 0; i < result.Length; i++)
            result[i] = points[i];

        return result;
    }

    public Transform[] GetPoints(Transform transform)
    {
        Transform[] points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
            points[i] = transform.GetChild(i);

        Transform[] result = new Transform[points.Length];

        for (int i = 0; i < result.Length; i++)
            result[i] = points[i];

        return result;
    }
}