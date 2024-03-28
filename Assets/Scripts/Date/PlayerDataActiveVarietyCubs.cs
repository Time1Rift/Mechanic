using System.Collections.Generic;

public class PlayerDataActiveVarietyCubs : AbstractPlayerDataString
{
    private readonly string NameFile = "ActiveCubes"; 
    private readonly string InitialData = "1 2 3 4";

    protected override void AddList(List<int> cubes, int number, int index = 0) => cubes[index] = number;

    protected override string ChangeInitialData() => InitialData;

    protected override string ChangeNameFile() => NameFile;
}