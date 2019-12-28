using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    private int health;

    public UnityEvent onDeath;

    // Start is called before the first frame update
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
}
