using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    [SerializeField]
    Rigidbody2D rb;

    void Start()
    {
        rb = rb.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = transform.forward * Time.deltaTime * bulletSpeed;
        transform.Translate(transform.up * Time.deltaTime * bulletSpeed);
        Destroy(this.gameObject, 5f);
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject) 
        {
            DestroyBullet();
        } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            DestroyBullet();
        }
    }
    void DestroyBullet() 
    {
        Destroy(this.gameObject);
    
    }
}
