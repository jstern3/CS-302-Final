//Jackson Stern
//Last Modified 12/4/2024
//This script instantiates enemies at the specified point
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, new Vector2(transform.position.x, transform.position.y), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
