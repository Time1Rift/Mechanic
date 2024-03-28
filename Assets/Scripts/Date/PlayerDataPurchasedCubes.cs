using System.Collections.Generic;

public class PlayerDataPurchasedCubes : AbstractPlayerDataString
{
    private readonly string NameFile = "PurchasedCubes";
    private readonly string InitialData = "1 2 3 4";

    protected override void AddList(List<int> cubes, int number, int index = 0) => cubes.Add(number);

    protected override string ChangeInitialData() => InitialData;

    protected override string ChangeNameFile() => NameFile;
}