using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class GoblinLineMovement : MonoBehaviour
{
    // public variables, exposed for editing.

    public float forceStrength = 1; //how fast the enemy moves
    
    public Vector2 direction; // what direction to move in.
    
    
    // private variables.

    private Rigidbody2D _rigidbody2D; // contains the rigid body attached to game object
    
    
    // add awake, called on load

    private void Awake()
    {
        // get and store rigidbody
        _rigidbody2D = GetComponent<Rigidbody2D>();
        direction = direction.normalized;
    }

    // Update is called once per frame
    private void Update()
    {
        // move in correct direction. with the set force Strength
        _rigidbody2D.AddForce(direction * forceStrength);
    }
}
