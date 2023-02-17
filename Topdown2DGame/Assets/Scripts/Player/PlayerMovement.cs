using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public PlayerStats stats;
    public Rigidbody2D rb2D;
    [SerializeField]
    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Input();
        
    }
    void FixedUpdate()
    {
        Movement();
    }


    void Input() 
    {
        move.x = UnityEngine.Input.GetAxisRaw("Horizontal");
        move.y = UnityEngine.Input.GetAxisRaw("Vertical");

        if (UnityEngine.Input.GetKeyDown(KeyCode.F)) 
        {
            stats.SpeedBuff(4);
        }
        
        
    
    }
    void Movement() 
    {
        var speedcalc = stats.baseSpeed;
        rb2D.MovePosition(rb2D.position + move * speedcalc * Time.fixedDeltaTime);

    }

}
