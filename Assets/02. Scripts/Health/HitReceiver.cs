using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnHitEvent : UnityEvent<int> { }

public class HitReceiver : MonoBehaviour, IDamageable
{
    [SerializeField]
    private OnHitEvent onHit;

    public void ReceiveHit(int damage)
    {
        onHit.Invoke(damage);
    }
}
