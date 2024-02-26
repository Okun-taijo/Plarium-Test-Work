using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectHealth : MonoBehaviour, IDamagable
{
    public int baseHealth;
    public int maxHealth;
    public int currentHealth;
    [SerializeField] protected UnityEvent onEndedHealth;
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    protected int GetCurrentHealth()
    {
        return currentHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            onEndedHealth.Invoke();
        }
    }
}
