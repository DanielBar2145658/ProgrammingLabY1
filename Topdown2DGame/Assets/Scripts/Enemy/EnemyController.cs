using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    BasicEnemy basicEnemy;


    // Start is called before the first frame update
    void Awake()
    {
        basicEnemy = new BasicEnemy();
        basicEnemy.Initialize(50f,50f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerHurtbox") 
        {
            Debug.Log("HurtboxColliding");
            basicEnemy.TakeDamage(5);
            basicEnemy.Knockback(0.5f,0.5f);


            
        
        }
    }

}
