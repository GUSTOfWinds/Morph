using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevelManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            //This checks a boolean thats set by the TreasureManager script, to see if the player has picked up the treasure and, therefore, can or can't progress.
            //It also resets this boolean in order for it to work properly in the next level (scene)
            if (other.GetComponent<PlayerTreasure>().treasureCollected)
            {
                other.GetComponent<PlayerTreasure>().treasureCollected = false;
                Debug.Log("Player is exiting scene, and moving to the next. Removing treasure collected");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Debug.Log("Player hasn't picked up the treasure yet, and can't progress further.");
            }
        }
    }
}