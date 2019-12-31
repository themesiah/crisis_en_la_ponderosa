using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnStartEvents : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onStart;

    private void Start()
    {
        onStart.Invoke();        
    }
}
