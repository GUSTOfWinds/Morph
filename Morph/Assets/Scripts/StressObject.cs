using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;

    // Update is called once per frame
    void Update()
    {
        //This, in tandem with a "onTriggerEnter", ensures that notes are hit if they are inside a certain area, and only under those circumstances
        if (Input.GetKeyDown(keyToPress) || Input.GetMouseButtonDown(0))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
                KeepYourCoolManager.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ActivatorButton")
        {
            canBePressed = true;
        }
    }
    //This makes it possible to track any "missed" notes, or notes that exited the trigger zone without being setActive(false)
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ActivatorButton")
        {
            canBePressed = false;
            KeepYourCoolManager.instance.noteMissed();
        }
    }
}