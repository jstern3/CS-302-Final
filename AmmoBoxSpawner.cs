//David Floyd
//Simple program to spawn in ammo boxe pre-fabs at a few fixed locations

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxSpawner : MonoBehaviour
{
    public GameObject ammoBoxPrefab; // Reference to the AmmoBox prefab

    void Start()
    {
        SpawnAmmoBoxes();
    }

    void SpawnAmmoBoxes()
    {
        // Hard-coded spawn locations
        Vector3[] spawnLocations = new Vector3[]
        {
            new Vector3(-2,0,0),
            new Vector3(2,0,0),
            new Vector3(0,0,0)
        };

        // Spawn an ammo box at each location
        foreach (Vector3 location in spawnLocations)
        {
            Instantiate(ammoBoxPrefab, location, Quaternion.identity);
        }
    }
}
