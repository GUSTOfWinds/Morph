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
                Debug.Log("Player is exiting scene, and moving to the next. Removing: " + keycard.name);
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1); //Anv�nder Async eftersom Unity p�st�r att det �r b�ttre. https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html
			} else {
                Debug.Log("Player hasn't picked up the " + keycard.name + " yet, and can't progress further.");
				//Add text object here telling the player to get the objective?
            }
        }
    }
}