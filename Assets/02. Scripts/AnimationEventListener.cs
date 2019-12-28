using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventListener : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onDieEvent;

    public void OnDie()
    {
        onDieEvent.Invoke();
    }
}
