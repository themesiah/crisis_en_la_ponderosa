using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventListener : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onShotEvent;
    [SerializeField]
    private UnityEvent onDieEvent;

    public void OnDie()
    {
        onDieEvent.Invoke();
    }

    public void OnShot()
    {
        onShotEvent.Invoke();
    }
}
