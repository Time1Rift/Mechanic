using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Figure : MonoBehaviour
{
    [field: SerializeField] public Transform Preview { get; private set; }
    [field: SerializeField] public TextMeshProUGUI NumberText { get; private set; }

    private string _nameFile;
    private int[,] _model;
    private Queue<Detail> _details = new();
    private Vector3 _positionOffset = Vector3.zero;
    private Transform _transform;

    public int Count => _details.Count;
    public Transform Transform => _transform;
    public Vector3 CentralPosition { get; private set; }

    public void Initialized(string nameFile)
    {
        _nameFile = nameFile;
        _transform = transform;
        ReadModel();
        AddDetails();
    }

    public Detail GetDetail() => _details.Dequeue();

    private void ReadModel()
    {
        char separatorSign = '\n';
        TextAsset textAsset = Resources.Load<TextAsset>($"Figure/{_nameFile}");
        string[] newFile = textAsset.text.Split(separatorSign);
        _model = new int[newFile.Length, newFile[0].Length - 1];

        for (int x = 0; x < _model.GetLength(0); x++)
            for (int y = 0; y < _model.GetLength(1); y++)
                if (int.TryParse(newFile[x][y].ToString(), out int number))
                    _model[x, y] = number;
    }

    private void AddDetails()
    {
        int indexX = (_model.GetLength(0) / 2) - 1;
        int indexY = (_model.GetLength(1) / 2) - 1;

        for (int x = 0; x < _model.GetLength(0); x++)
        {
            Detail detal = new Detail();

            for (int y = 0; y < _model.GetLength(1); y++)
            {
                if (_model[x, y] != 0)
                    detal.AddPartDetail(_model[x, y], _positionOffset);

                if (x == indexX && y == indexY)
                    CentralPosition = _positionOffset;

                _positionOffset += Vector3.right;
            }

            _details.Enqueue(detal);
            _positionOffset.x = 0;
            _positionOffset += Vector3.down;
        }
    }
}