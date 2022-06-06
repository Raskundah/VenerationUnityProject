using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            
            
            var colPoint = col.GetComponent<GoblinLineMovement>();

            if (colPoint != null)
            {

                colPoint.direction = -colPoint.direction;
                colPoint.FlipGoblin();

            }

        }
    }
}
