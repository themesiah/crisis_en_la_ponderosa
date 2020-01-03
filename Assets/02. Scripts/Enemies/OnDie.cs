using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDie : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent onDie;

    public void AddDieCallback(UnityAction action)
    {
        onDie.AddListener(action);
    }

    public void Invoke()
    {
        onDie.Invoke();
    }
}
