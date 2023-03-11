using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour
{
    enum enemyType { None,Basic, Medium, Tough}

    [SerializeField]
    enemyType typeEnemy;
    BasicEnemy basicEnemy;


    // Start is called before the first frame update
    void Awake()
    {


        
        basicEnemy = new BasicEnemy();
        SetEnemyType(typeEnemy);


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetEnemyType(enemyType enemy) 
    {
        typeEnemy = enemy;

        switch (typeEnemy)
        {
            case enemyType.Basic:
                basicEnemy.Initialize(50f, 50f);
                return;
            case enemyType.Medium:
                basicEnemy.Initialize(100f, 100f);
                return;
            case enemyType.Tough:
                basicEnemy.Initialize(150f, 150f);
                return;

        }

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerHurtbox") 
        {
            Debug.Log("HurtboxColliding");
            

            basicEnemy.TakeDamage(5);
            basicEnemy.Knockback(0.5f,0.5f);

            if (basicEnemy.curHealth < 0) 
            {
                basicEnemy.curHealth = 0;
                basicEnemy.Dead();
                Destroy(this.gameObject);
            }


            
        
        }
    }

}
