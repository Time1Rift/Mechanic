using UnityEngine;

public class PartDetail
{
    public PartDetail(int number, Vector3 position)
    {
        Number = number;
        Position = position;
    }

    public int Number { get; private set; }
    public Vector3 Position { get; private set; }
}