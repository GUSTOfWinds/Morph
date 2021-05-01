using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Player")
        {
            
            // Skriv in s� man kommer till Main Menu efter man d�r h�r.
            Time.timeScale = 0;
            
            // anropa en viss scen. Den scenen som ska kallas p� n�r man �r f�ngad. 
            // skriv in vilken tag det �r som har f�ngat dig. Ifall det �r en vakt �r det slut ifall det �r en hund s� ska man ta sig till keep your cool.

            Debug.Log("Pang");
            SceneManager.LoadScene("MainMenu");
            

        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "MyGameObjectTag")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }
}
