//David Floyd and Jackson Stern
//Last Modified: 12/04/2024
//General script for the bullets that deals with their movement and destruction
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float Bulletspeed;
    private Rigidbody2D body;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (transform.localScale.x < 0)
        {
            Bulletspeed = Bulletspeed * -1;
        }
        else
        {
            Bulletspeed = Bulletspeed * 1;
        }
        //body.velocity = new Vector2(Bulletspeed, 0);
        body.velocity = transform.right * Bulletspeed;
    }

    void Update()
    {
  
    }

    //Written by Jackson Stern
    //Destroys the bullet when it collides with another object
    private void OnCollisionEnter2D(Collision2D other)
    {
        Object.Destroy(gameObject);
    }

}

