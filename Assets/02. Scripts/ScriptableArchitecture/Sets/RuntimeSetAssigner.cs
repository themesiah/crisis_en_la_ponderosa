using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeSetAssigner<T, T2> : MonoBehaviour where T : RuntimeSet<T2> where T2 : new()
{
    [SerializeField]
    private T runtimeSet;
    [SerializeField]
    private T2 component;
    
    protected void OnEnable()
    {
        runtimeSet.Add(component);
    }

    protected void OnDisable()
    {
        runtimeSet.Remove(component);
    }
}
