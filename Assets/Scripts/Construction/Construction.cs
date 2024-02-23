using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    [SerializeField, Min(0)] private int _number = 4;

    private List<Bolt> _bolts = new();

    public bool TryNumber(int number) => _number == number;

    public void SetBolt(Bolt bolt)
    {
        bolt.transform.SetParent(transform);
        bolt.transform.position = transform.position;
        _bolts.Add(bolt);
    }
}