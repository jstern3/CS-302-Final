//Jackson Stern
//Last Modified: 12/5/2024
//This program uses a list(c++ vector) to generate a random room once the player reaches a room exit.
//This is our code that satisfies the data structure requirement(hopefully)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public List<GameObject> rooms = new List<GameObject>(3);
    public GameObject room1;
    public GameObject room2;
    public GameObject room3;
    //public GameObject room4;
    public float count = 1;
    public LogicManagerScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        rooms.Insert(0, room1);
        rooms.Insert(1, room2);
        rooms.Insert(2, room3);
       // rooms.Add(room4);   
    }

    // Update is called once per frame
    void Update()
    {

    }

    //When the player enters the exit of the room, call generate rooms
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Working");
            GenerateRooms();
            //Ensures that the trigger can only work once
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    //Generates a random index and then generates the specified room from the list
    private void GenerateRooms()
    {
        int index = Random.Range(0, rooms.Count - 1);
        //Creates a new random room
        GameObject r = Instantiate(rooms[index]) as GameObject;
        count = logic.GetRoomsCleared();
        //Ensures that the room is moved to the correct position, rooms are 25 units wide
        r.transform.localPosition = new Vector2(25f*count,0);
        //Activates the newly spawned room
        r.SetActive(true);
        count++;

    }
}
