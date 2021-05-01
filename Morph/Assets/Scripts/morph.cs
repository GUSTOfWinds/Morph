<<<<<<< HEAD
﻿using System.Collections; using System.Collections.Generic; using UnityEngine;  public class morph : MonoBehaviour { 	public GameObject startObject;  	private bool morphed = false; 	private GameObject currentObject;  	void Start()     { 		currentObject = Instantiate(startObject, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform); 	}  	public bool isMorphed() { 		return morphed; 	}  	public void morphObject(GameObject newObj) { 		newObj = Instantiate(newObj, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform); 		morphed = morphed ? morphed = false : morphed = true;  		Destroy(currentObject); 		currentObject = newObj; 		Debug.Log("You are now a: " + currentObject.name); 	} 	public void morphObject() { 		morphObject(startObject); 	} } 
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morph : MonoBehaviour
{
	public GameObject startObject;

	private bool morphed = false;
	private GameObject currentObject;

	// Start is called before the first frame update
	void Start()
    {
		currentObject = Instantiate(startObject, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
	}

    // Update is called once per frame
    void Update()
    {

    }

	public bool isMorphed() {
		return morphed;
	}

	public void morphObject(GameObject newObj) {
		if(morphed) {newObj = startObject;}

		newObj = Instantiate(newObj, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
		//newObj = Instantiate(newObj, gameObject.transform);
		gameObject.GetComponent<player>().toggleMovement();
		morphed = morphed ? morphed = false : morphed = true;

		Destroy(currentObject);
		currentObject = newObj;
		Debug.Log("You are now a: " + currentObject.name);
	}
}
>>>>>>> main
