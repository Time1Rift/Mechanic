using System;

public interface IBoltsDrawed
{
    public event Action<BoltColumn> BoltsDrawed;
}