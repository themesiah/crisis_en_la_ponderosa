using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeSingleAssigner<T, T2> : MonoBehaviour where T : RuntimeSingle<T2> where T2 : new()
{
    [SerializeField]
    private T runtimeSingle;
    [SerializeField]
    private T2 component;
    
    protected void OnEnable()
    {
        runtimeSingle.Set(component);
    }

    protected void OnDisable()
    {
        runtimeSingle.Set(new T2());
    }
}
