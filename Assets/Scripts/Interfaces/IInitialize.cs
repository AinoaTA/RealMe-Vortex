using UnityEngine;
public interface IInitialize
{
    public abstract void InitializeAwake();

    public void InitializeStart() { }
}