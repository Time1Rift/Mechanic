using System;

public interface IBoltCreated
{
    public event Action<Bolt> BoltCreated;
}