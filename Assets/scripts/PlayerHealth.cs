using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Purpose: handle player damage and dying When told to do so by a hazard.
public class PlayerHealth : MonoBehaviour
{
    private int currentHealth;
    public int maxHealth = 100;

    public float hitInvulnMaxTime;
    private float hitTime = 0;

    private void Awake()
    {
        currentHealth = maxHealth;

        // initializing health to be max health on spawn.
    }

    //action kill player for now, delete object

    public void Kill()
    {
        // reduce health

        Destroy(gameObject);
    }

    public void ChangeHealth(int changeamount)

    //condition
    //has it been long enough since last damage
{

        if (Time.time >= hitTime + hitInvulnMaxTime)
        {
                // action: damage
            currentHealth += changeamount;

            hitTime = Time.time;

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }    
}
