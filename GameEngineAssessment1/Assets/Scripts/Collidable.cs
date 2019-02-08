using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract class Collidable : MonoBehaviour
{
    protected int maxHealth = 1;
    protected int currentHealth = 1;
    protected int Health
    {
        set
        {
            maxHealth = value;
            currentHealth = value;
        }
    }
    protected int damage = 1; //should probably be moved to a sub-class

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
