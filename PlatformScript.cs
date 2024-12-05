//Jackson Stern
//Last Modified: 12/4/2024
//This programs allows for our platforms to work like super-smash-bros style ones
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
//Based off of the following tutorial
//https://www.youtube.com/watch?v=M_kg7yjuhNg&t=202s
public class PlatformScript : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Increases waitTime while the down arrow is held
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.5f;
        }

        //If the down arrow is held for long enough, rotate the effector so the player will drop through
        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
        //Flips the effector back once the player jumps again
        if (Input.GetKey(KeyCode.UpArrow))
        {
            effector.rotationalOffset = 0;
        }
    }

    //Makes sure to flip the platform rightside up if the player collides with it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        effector.rotationalOffset = 0;
    }
}
