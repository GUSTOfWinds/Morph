using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    //WARNING: SCUFFED CODE
    //the bool "repeat" and the if(repeat) statement in update, exists so that textContent can be accessed properly, as setting it to false in start causes accessing issues
    //If someone knows how to fix this, or less scuffed way that doesn't involve using update, let me(GUST) know. The goal is to have all the components defined in start, and the text
    //To not be visable when the player begins
    
    private bool removeObject = false;
    private bool canBeTaken = true;
    private float timer = 0f;
    private float deletionTime = 1f;
    public MeshRenderer mesh;
    public ParticleSystem particles;
    public GameObject textObject;
    public TextMeshProUGUI textContent;
    public bool repeat = true;


    //ADD CODE: Define any needed audio systems

    private void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
        particles = gameObject.GetComponent<ParticleSystem>();
        textObject = GameObject.Find("PopUpText");
        textContent = textObject.GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (repeat)
        {
            textObject.SetActive(false);
            repeat = false  ;
        }


        if (removeObject)
        {
            timer += Time.deltaTime;
            if(timer >= deletionTime)
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider collider) {
		if(collider.gameObject.tag.Equals("Player") && canBeTaken) {

			collider.gameObject.GetComponent<ItemController>().addItem(gameObject);
            removeObject = true;
            canBeTaken = false;
            mesh.enabled = false;

            textObject.SetActive(true);
            textContent.text = "Acquired: " + gameObject.name;
            Invoke("disableText", deletionTime);
            particles.Play();
            //ADD CODE: PLAYing of the Audio
		}
	}

    //Called with invoke, in the TriggerEnter method
    private void disableText()
    {
        textObject.SetActive(false);
    }
}
