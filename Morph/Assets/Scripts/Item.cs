using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	private void OnTriggerEnter(Collider collider) {
		if(collider.gameObject.tag.Equals("Player")) {
			collider.gameObject.GetComponent<ItemController>().addItem(gameObject);
			Destroy(gameObject);
		}
	}
}
