//Jackson Stern 
//Last Modified: 12/04/2024
//This is a basic room script that destroys the room after the player is two rooms away
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < Player.transform.position.x - 50 || transform.position.y < Player.transform.position.y - 200)
        {
            if(gameObject.name != "Room 1" && gameObject.name != "Room 2" && gameObject.name != "Room 3")
                Object.Destroy(gameObject);
        }
    }
}
