using System;

public interface IButtonCleaningShelfCoins
{
    public event Action<IButtonCleaningShelfCoins> TriedPay;

    public void ClearShelf();
}