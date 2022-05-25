using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// Makes the script only work with buttons, or a component with a button
[RequireComponent(typeof(Button))]


// The additional items in this list let us respond to mouse or touch events.
public class HeldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    // Store button here to be used.
    private Button button;

    //Track condition of button press.
    private bool isButtonPressed;

    public void OnPointerDown(PointerEventData eventData) // this function gets called by unity when the user first clicks the button.
    {   

        //ignore if button is not interactable
        if (!button.interactable) return;

        // record button press value
        isButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonPressed = false; //called by unity when user releases the button, and records button isn't pressed
    }


    // called by unity when user moves finger/cursor away from button while held down
    public void OnPointerExit(PointerEventData eventData)
    {
        isButtonPressed = false;
    }

    // Start is called before the first frame update
    void Awake()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        // If we have observed if the button is being pressed...

        if(isButtonPressed)
        {   // call the on click function set up in Unity for this button
            button.onClick?.Invoke();
        }
    }
}
