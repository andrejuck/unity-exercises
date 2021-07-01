using UnityEngine;

public interface IPooller
{
    void StartPool();
    GameObject GetPooledObject();
}

