using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressScroller : MonoBehaviour
{
    public float stressSpeed;
    public bool hasBegun;
    // Start is called before the first frame update
    void Start()
    {
        stressSpeed = stressSpeed / 60f;
    }
    // Update is called once per frame
    void Update()
    {
        //If the game has started, then the stress balls should scroll appropriatly.
        //the Begun function is altered by another script, KeepYourCoolManager, through a class reference
        if (hasBegun)
        {
            transform.position -= new Vector3(stressSpeed * Time.deltaTime, 0f, 0f);
        }
    }
}