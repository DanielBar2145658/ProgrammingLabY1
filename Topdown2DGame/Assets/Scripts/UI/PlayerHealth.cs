using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public PlayerStats playerStats;
    public TMP_Text healthDisplay;
    // Start is called before the first frame update
    void Start()
    {
        var maxHealth = playerStats.baseHealth;
        var currentHealth = playerStats.currentHealth;

        healthDisplay.SetText("{0} / {1}", currentHealth, maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
