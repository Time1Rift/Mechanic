using System;

public interface IPressed
{
    public event Action<bool> Pressed;
}