using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int ammoAmount = 35; // Amount of ammo the box provides

    private void OnTriggerEnter(Collider other) // For 3D
    {
        if (other.CompareTag("Player"))
        {
            Shoot playerShoot = other.GetComponent<Shoot>();
            if (playerShoot != null)
            {
                playerShoot.bulletsleft += ammoAmount; // Add ammo to the player's count
            }
            Destroy(gameObject); // Destroy the ammo box
        }
    }

    // For 2D (if needed)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Shoot playerShoot = other.GetComponent<Shoot>();
            if (playerShoot != null)
            {
                playerShoot.bulletsleft += (35-playerShoot.bulletsleft);//ammoAmount; // Add ammo to the player's count
            }
            Destroy(gameObject); // Destroy the ammo box
        }
    }
}
