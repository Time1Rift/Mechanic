using System.Collections.Generic;
using System;
using UnityEngine;
#if UNITY_WEBGL && !UNITY_EDITOR
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;
#endif

public abstract class AbstractPlayerDataString
{
    private readonly string NameFile = "";
    private readonly string InitialData = "1 2 3 4";

    private List<int> _cubes = new();

    public AbstractPlayerDataString()
    {
        NameFile = ChangeNameFile();
        InitialData = ChangeInitialData();
        UploadData();
    }

    public void ChangeCubes(int number, int index = 0)
    {
        string text = "";
        AddList(_cubes, number, index);

        for (int i = 0; i < _cubes.Count; i++)
            text += i == 0 ? $"{_cubes[i]}" : $" {_cubes[i]}";

        PlayerPrefs.SetString(NameFile, text);
        PlayerPrefs.Save();
    }

    public List<VarietyBolt> GetCubes(ListVarietyBolts bolts)
    {
        List<VarietyBolt> varietyBolt = new();

        for (int i = 0; i < _cubes.Count; i++)
            varietyBolt.Add(bolts.GetVarietyBolt(_cubes[i]));

        return varietyBolt;
    }

    protected abstract string ChangeNameFile();

    protected abstract string ChangeInitialData();

    protected abstract void AddList(List<int> cubes, int number, int index = 0);

    private void UploadData()
    {
        if (PlayerPrefs.HasKey(NameFile) == false)
            PlayerPrefs.SetString(NameFile, InitialData);

        char separatorSign = ' ';
        string text = PlayerPrefs.GetString(NameFile);
        string[] arrayOfText = text.Split(separatorSign);
        
        foreach (string number in arrayOfText)
            _cubes.Add(Convert.ToInt32(number));
    }
}