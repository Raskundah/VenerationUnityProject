using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Purpose: This script handles the killing of players on collision with the object that has this script.

public class Hazard : MonoBehaviour
{
    //get playerhealth component


    // how much damege this does
    [Tooltip("Positive number removes the health")]
    public int hazardDamage; 

    private void OnCollisionStay2D(Collision2D collision)    
    {

        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        // condition
        //when our hazard object collides with player

        //enoug time has passed since we last collided;
       if (playerHealth != null)
        {
            playerHealth.ChangeHealth(-hazardDamage);
        }
    }
}
