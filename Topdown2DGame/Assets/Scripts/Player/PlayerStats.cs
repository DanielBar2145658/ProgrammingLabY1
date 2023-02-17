using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float baseHealth;
    public float currentHealth;

    public float baseDamage;
    public float baseSpeed;
    public float baseAttackSpeed;


    public event System.Action<float, float> StatBoost;
    public event System.Action<float, float> ChangeHealth;
    public event System.Action<float> ChangeSpeed;


    private void Awake()
    {
        currentHealth = baseHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnStatChangeBaseHealth(float amount) 
    {
        baseHealth += amount;
        currentHealth = baseHealth;
        if (StatBoost != null) 
        {
            StatBoost(baseHealth,currentHealth);
        }
    }
    public virtual void TakeDamage(float amount) 
    {
        currentHealth -= amount;


    
    }
    public virtual void SpeedBuff(float amount)
    {
        baseSpeed += amount;



    }

}
