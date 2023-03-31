using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public PlayerStats stats;
    public Rigidbody2D rb2D;
    public Transform shootPoint;
    public Transform Arm;
    public GameObject bullet;

    protected Camera cam;
    [SerializeField]
    protected Vector3 mousePosition;
    private bool m_HasShot;

    private int coinAmount;
    





   [SerializeField]
    Vector2 move;

    private void Awake()
    {
        
    }

    

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>().GetComponent<Camera>();
        m_HasShot = false;
    
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition) - Arm.transform.position;
        
        PlayerArm();

        GetCoinAmount();
        


        
    }
    void FixedUpdate()
    {
        Movement();
        
    }


    void PlayerInput()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.F))
        {
            stats.SpeedBuff(2);
        }

        if (Input.GetMouseButton(0) && !m_HasShot) 
        {
            StartCoroutine(Shoot());
        }
    
    }
    void Movement() 
    {
        var speedcalc = stats.baseSpeed;
        rb2D.MovePosition(rb2D.position + move * speedcalc * Time.fixedDeltaTime);

    }

    void PlayerArm() 
    {
        mousePosition.Normalize();
        // note to self Everything uses Vector3 
        Vector3 aimDirection = mousePosition - transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        Arm.rotation = Quaternion.Euler(0f,0f,angle);
        
    
    }

    IEnumerator Shoot() 
    {

        m_HasShot = true;
        yield return new WaitForSeconds(0.5f);

        Instantiate(bullet, shootPoint.position, shootPoint.transform.rotation);

        m_HasShot = false;
    }

    public Vector2 GetPlayerPosition() 
    {
        return gameObject.transform.position;
        
    }

    public int GetCoinAmount() 
    {
        return coinAmount;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Coin")
        {
            Debug.Log("Coin Get");
            coinAmount++;


        }
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 40, 60, 90), GetCoinAmount().ToString());
    }
}
