using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // collision target;

        GameObject gameObject = collision.gameObject;

        //get name of object

        string gameName = gameObject.name;

        // get tag

        string objectTag = gameObject.tag;

        // get object physics layer

        int objectLayer = gameObject.layer;

        /*  we can check if a script is attatched to collision target, and get it.
         getting a component from other object */

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        Debug.LogWarning("We have collided!");
        Debug.LogWarning(gameName);
        Debug.LogWarning(objectTag);
        Debug.LogWarning(objectLayer);

        if(spriteRenderer != null)

        spriteRenderer.color = Color.red;

    }
}
