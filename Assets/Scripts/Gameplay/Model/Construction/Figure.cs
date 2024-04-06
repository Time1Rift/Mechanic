using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Figure : MonoBehaviour
{
    [field: SerializeField] public Transform Preview { get; private set; }
    [field: SerializeField] public TextMeshProUGUI NumberText { get; private set; }
    [SerializeField] private string _nameFile;

    private int[,] _model;
    private Queue<Detail> _details = new();
    private Vector3 _positionOffset = Vector3.zero;
    private Transform _transform;

    public int Count => _details.Count;
    public Transform Transform => _transform;

    public void Initialized()
    {
        _transform = transform;
        ReadModel();
        AddDetails();
    }

    public Detail GetDetail() => _details.Dequeue();

    private void ReadModel()
    {
        string[] newFile = File.ReadAllLines($"Assets/Figure/{_nameFile}.txt");
        _model = new int[newFile[0].Length, newFile.Length];

        for (int x = 0; x < _model.GetLength(0); x++)
            for (int y = 0; y < _model.GetLength(1); y++)
                _model[x, y] = int.Parse(newFile[x][y].ToString());
    }

    private void AddDetails()
    {
        for (int x = 0; x < _model.GetLength(0); x++)
        {
            Detail detal = new Detail();

            for (int y = 0; y < _model.GetLength(1); y++)
            {
                if(_model[x, y] != 0)
                    detal.AddPartDetail(_model[x, y], _positionOffset);

                _positionOffset += Vector3.right;
            }

            _details.Enqueue(detal);
            _positionOffset.x = 0;
            _positionOffset += Vector3.down;
        }
    }
}