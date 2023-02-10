using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour
{
    
    public float curHealth;
    public float curArmour;
    public bool isDead;

    public virtual void Initialize(float maxHealth, float maxArmour)
    {
        curHealth = maxHealth;
        curArmour = maxArmour;
        isDead = false;
    }

    public virtual void TakeDamage(int amount) 
    {


        if (curArmour <= 0)
        {
            curArmour = 0;
            curHealth -= amount;
            Debug.LogWarning("Took Health Damage");
            Knockback(0, 0);
        }
        else if (curHealth <= 0)
        {
            curHealth = 0;
            Dead();
        }
        else 
        {
            curArmour -= amount;
            Debug.LogWarning("Took shield Damage");

        }
    
    }
    public virtual void Knockback(float x, float y) 
    {
        //Vector2 knockback = new Vector2();
        Debug.Log($"Knockbacked x:{x}, y:{y}");
    }
    public virtual void Dead() 
    {
        Debug.Log("died");

    
    }
}
