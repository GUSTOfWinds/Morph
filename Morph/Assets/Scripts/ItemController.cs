using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

	public List<GameObject> items = new List<GameObject>();

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
	}
}
