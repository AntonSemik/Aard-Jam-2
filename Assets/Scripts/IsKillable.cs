using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsKillable : MonoBehaviour
{
    [SerializeField] int maxHealth;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int value)
    {
        currentHealth -= value;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
