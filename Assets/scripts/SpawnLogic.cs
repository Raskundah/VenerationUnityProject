using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour
{

    public Transform spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = spawnLocation.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
