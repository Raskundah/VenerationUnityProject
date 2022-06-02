using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTotal : MonoBehaviour
{
    //static shares the variable's value across all things referencing the variable / sharing the script.

    private static int scoreValue = 0;
    public Text scoreDisplay;

    public void ScoreUpdate(int toAdd)
    {
        scoreValue += toAdd;

        scoreDisplay.text = scoreValue.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        scoreDisplay.text = scoreValue.ToString();
    }
}
