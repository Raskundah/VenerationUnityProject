using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class SpriteFlip : MonoBehaviour


{
    
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        if (_renderer == null)
        {
            Debug.LogError("Player Sprite is missing a renderer");
        }
    }

    
    public void Update()
    {
        _renderer.flipX = PlayerMovement.isFlipped;
    }
}
