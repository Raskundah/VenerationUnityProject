using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : MonoBehaviour

{   [SerializeField]
    private int pickupValue = 10;

    // called by unity when this object overlaps with another object

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // only triggered by player collision

        // we will know they're player if they have the ScoreTotal script

        //check if object has component

        ScoreTotal scoreTotalScript = collision.GetComponent<ScoreTotal>();

        if(scoreTotalScript != null)
        {
            //this means the object was player and we can add the score

            //add to score

            scoreTotalScript.ScoreUpdate(pickupValue);

            Destroy(gameObject);
        }
    }


}
