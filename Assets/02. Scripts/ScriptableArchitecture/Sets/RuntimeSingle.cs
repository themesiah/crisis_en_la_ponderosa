using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSingle<T> : ScriptableObject
{
    [SerializeField]
    private T Item;

    public void Set(T thing)
    {
        Item = thing;
    }

    public T Get()
    {
        return Item;
    }
}