using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BasicEnemy : EnemyBehaviour
{


    public override void Initialize(float maxHealth, float maxArmour)
    {
        base.Initialize(maxHealth, maxArmour);
    }

    public override void Knockback(float x, float y)
    {
        base.Knockback(x, y);


    }
    public override void Dead()
    {
        base.Dead();
        Debug.Log("Basic Enemy Down!!");
        
    }
    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        
        
    }
}
