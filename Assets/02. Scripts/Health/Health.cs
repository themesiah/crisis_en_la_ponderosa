using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField]
    private int maxHealth;
    private int health;

    public UnityEvent onDeath;
    
    void Start()
    {
        health = maxHealth;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            onDeath.Invoke();
        }
    }

    public void ReceiveHit(int damage)
    {
        Damage(damage);
    }
}
