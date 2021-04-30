using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morph : MonoBehaviour
{
	public GameObject currentObject;
	public GameObject[] models;

	private bool morphed = false;
	private GameObject startObject;

	// Start is called before the first frame update
	void Start()
    {
		startObject = currentObject;
	}

    // Update is called once per frame
    void Update()
    {

    }

	public bool isMorphed() {
		return morphed;
	}

	public void morphObject(string input) {
		GameObject newObj = currentObject;
		switch(input) {
			case "kitchenChair":
				newObj = models[0];
				break;
			case "genericBox":
				newObj = models[1];
				break;
			case "barrel":
				newObj = models[2];
				break;
		}

		gameObject.GetComponent<player>().toggleMovement();
		morphed = morphed ? morphed = false : morphed = true;
		if(!morphed) {newObj = startObject;}

		currentObject.SetActive(false);
		newObj.SetActive(true);
		currentObject = newObj;
		Debug.Log("You are now a: " + newObj.name);
	}
}
