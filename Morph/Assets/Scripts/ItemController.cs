using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour {

	public List<GameObject> items = new List<GameObject>();

	public GameObject textPopUp;
	public ParticleSystem particlePopUp;

	public GameObject getItem(GameObject getItem) {
		return items.Contains(getItem) ? getItem : null;
	}

	public bool hasItem(GameObject hasItem) {
		return items.Contains(hasItem) ? true : false;
	}

	public bool removeItem(GameObject removeItem) {
		return items.Remove(removeItem);
	}

	public void addItem(GameObject addItem) {
		items.Add(addItem);
		addPopup(addItem);
		Debug.Log("Picked Up:" + addItem.name);
	}

    //
    private void Start()
    {
		textPopUp.SetActive(false);

	}
	
	//IMPLEMENT ANY SOUND TO BE PLAYED IN THIS METHOD BELOW
	public void addPopup(GameObject item)
    {
		textPopUp.SetActive(true);
		particlePopUp.Play();
		Invoke("popupEnd", 1);

    }
	public void popupEnd()
    {
		textPopUp.SetActive(false);
		particlePopUp.Stop();
    }
}
