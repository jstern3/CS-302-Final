//Jackson Stern
//Last Modified 12/4/2024
//This is a general enemy script with a potential enemy patrol script that we ended up not implementing
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//Based off of the following tutorial:
//https://www.youtube.com/watch?v=RuvfOl8HhhM&t=453s
public class EnemyPatrol : MonoBehaviour
{
    //public GameObject pointA;
    //public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed = 5;
    private bool isAlive = true;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //currentPoint = pointB.transform;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            Debug.Log(speed);
            //Move to the left at the specified speed
            rb.velocity = new Vector2(-speed, 0);
            /* Originally implemented patrol code 
            Vector2 point = currentPoint.position - transform.position;
            //Moves enemy from left to right, reversing direction when a point is reached
            if (currentPoint == pointB.transform)
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(speed, 0);
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < .5f && currentPoint == pointB.transform)
            {
                currentPoint = pointA.transform;
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < .5f && currentPoint == pointA.transform)
            {
                currentPoint = pointB.transform;
            }
            */
        }
        //Checks to see if the enemy is dead, if so, flip the sprite, have it fall for 2 seconds, and then deactivate the object
        if (!isAlive)
        {
            GetComponent<SpriteRenderer>().flipY = true;
            rb.velocity = new Vector2(0, -speed);
            timer++;
            if(timer >= 120)
            {
                Object.Destroy(gameObject);
            }
        }
    }
/*Unimplemented function to see patrol points with the above unimplemented patrol code
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, .5f);
        Gizmos.DrawWireSphere(pointB.transform.position, .5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
*/

    //Checks to see if the colliding object is a bullet, if so deactivate collision and set status to dead.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Collided");
            GetComponent<BoxCollider2D>().enabled = false;
            isAlive = false;
        }
    }
}
