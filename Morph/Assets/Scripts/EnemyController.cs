using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision){
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag.Equals("Player")){
            var morph = collision.gameObject.GetComponent<MorphManager>();

            if (morph.isMorphed())
            {
                Debug.Log("Haha e mofad");
            }
            else
            {
                // Skriv in så man kommer till Main Menu efter man dör här.
                SceneManager.LoadScene("MainMenu");
            }


            // anropa en viss scen. Den scenen som ska kallas på när man är fångad. 
            // skriv in vilken tag det är som har fångat dig. Ifall det är en vakt är det slut ifall det är en hund så ska man ta sig till keep your cool.

            
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "MyGameObjectTag"){
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }
}
