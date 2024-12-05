using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    public float fireRate = 0.1f;
    private float nextFireTime = 0f;
    public float bulletsleft = 35f;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime && bulletsleft > 0)
        {
            Instantiate(bulletPrefab,shootingPoint.position, transform.rotation);
            nextFireTime = Time.time + fireRate;
            bulletsleft--;
        }
        bulletPrefab.transform.localScale = transform.localScale/20;
    }

     private void OnCollisionEnter2D(Collision2D collision){
         if(collision.gameObject.tag == "Ammo" && bulletsleft < 35) {
             bulletsleft += (35 - bulletsleft); //refil ammo to 35;
         }
     }
}
