using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Ensure TextMeshPro is included

public class AmmoText : MonoBehaviour
{
    public TextMeshProUGUI text; // The UI Text object
    private Shoot shoot;         // Reference to the Shoot script
    private float lastAmmoCount = -1f;

    void Start()
    {
        // Find the Shoot component dynamically
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            shoot = player.GetComponent<Shoot>();
        }

        if (shoot == null || text == null)
        {
            Debug.LogError("Shoot script or Text reference is missing. Ensure Player has the Shoot script and Text is assigned in the Inspector.");
            enabled = false; // Disable the script if dependencies are missing.
            return;
        }

        UpdateAmmoText();
    }

    void Update()
    {
        if (shoot.bulletsleft != lastAmmoCount) // Update only when ammo count changes
        {
            UpdateAmmoText();
        }
    }

    public void UpdateAmmoText()
    {
        lastAmmoCount = shoot.bulletsleft;
        text.text = $"{lastAmmoCount} / 35";
    }
}
