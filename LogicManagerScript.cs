//Jackson Stern
//Last Modified: 12/4/2024
//This is a genearl logic manager that deals with gameover conditions as well as keeping track of the room count
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject player;
    public float roomsCleared = 0;
    //This program reloads the level when the restart button is pushed
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //This code activates the gameover screen and deactivates the player's collision
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        player.GetComponent<BoxCollider2D>().enabled = false;
    }
    //This program returns the amount of rooms that have been cleared
    public float GetRoomsCleared()
    {
        roomsCleared++;
        return roomsCleared;
    }
}
