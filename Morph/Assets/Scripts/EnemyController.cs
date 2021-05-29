using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
	//Detect collisions between the GameObjects with Colliders attached
	private void OnTriggerEnter(Collider collider) {
		//Check for a match with the specified name on any GameObject that collides with your GameObject
		if (collider.tag.Equals("Player")){
            var morph = collider.gameObject.GetComponent<MorphController>();

            if (morph.isMorphed())
            {
                Debug.Log("Player is morphed.");
				//Play "HMM" sound?
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("DeathCaptured");
				collider.GetComponent<PlayerController>().toggleMovement();
				GameOver();
                // Kolla application load scene.
            }
            // anropa en viss scen. Den scenen som ska kallas på när man är fångad. 
            // skriv in vilken tag det är som har fångat dig. Ifall det är en vakt är det slut ifall det är en hund så ska man ta sig till keep your cool.
        }
	}
	
	private void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

}
