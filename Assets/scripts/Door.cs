using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string targetScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // we overlapped

        //check if player

        if (collision.CompareTag("Player"))
        {
            // ACTION! CHANGE SCENE!!!!

            SceneManager.LoadScene(targetScene);
        }
    }
}
