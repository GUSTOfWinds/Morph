using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
	public GameObject keycard;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("Player")){
			ItemController script = collider.GetComponent<ItemController>(); //Unsure if this works properly
			if (script.hasItem(keycard)){
				script.removeItem(keycard);
                Debug.Log("Player is exiting scene, and moving to the next. Removing" + keycard.name + " collected");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else{
                Debug.Log("Player hasn't picked up the treasure yet, and can't progress further.");
            }
        }
    }
}