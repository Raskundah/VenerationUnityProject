using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Purpose: handle player damage and dying When told to do so by a hazard.
public class PlayerHealth : MonoBehaviour
{
    public static int currentHealth;
    public int maxHealth = 100;

    public float hitInvulnMaxTime;
    private float hitTime = 0;
    public Text healthDisplay;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthUpdate();

        // initializing health to be max health on spawn.
    }

    //action kill player for now, delete object

    public void Kill()
    {
        // reduce health

        Destroy(gameObject);
    }

    public void healthUpdate()
    {
        healthDisplay.text = currentHealth.ToString();
    }

    public void ChangeHealth(int changeAmount)

    //condition
    //has it been long enough since last damage
{

        if (Time.time >= hitTime + hitInvulnMaxTime)
        {
                // action: damage
            currentHealth += changeAmount;

            hitTime = Time.time;

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    public void Update()
    {
        healthUpdate();
    }
}
