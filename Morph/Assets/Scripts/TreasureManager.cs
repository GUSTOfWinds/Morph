using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //This checks if the thing colliding with the object is the player, so that something only happens if the player is interacting with it
        //It also disables the object to "pick up" the treasure, and changes a boolean, which is later checked by another script in an if/else statement
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerTreasure>().treasureCollected = true;
            //CODE SPACE: Playing an audio jingle, or some SFX visual effect.
            Debug.Log("Player has picked up the treasure.");
            gameObject.SetActive(false);
        }
    }
}