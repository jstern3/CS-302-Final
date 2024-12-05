//Jackson Stern
//Last Modified 12/4/2024
//This program reverses an enemies velocity when they collide with the given point
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ReversalPointScript : MonoBehaviour
{
    private EnemyPatrol script;
    private float count = 0;
    private float negativeSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When the trigger interacts with a collider, check to see if the object is an enemy, and if so, reverse their velocity
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
           // Debug.Log("Hit");
            GameObject en = other.gameObject;
            script = en.GetComponent<EnemyPatrol>();
          //  Debug.Log("Original " + script.speed);
            if (count == 0)
            {
                negativeSpeed = -script.speed;
                count++;
            }
            script.speed = negativeSpeed;
           // Debug.Log("New" + script.speed);
                
        }
    }
}
