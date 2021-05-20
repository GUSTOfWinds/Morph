using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour{
	public GameObject player;
	public GameObject keycard;
	public GameObject activate;
	private void OnCollisionEnter(Collision collision) {
		if(collision.transform.tag.Equals(player.tag) && player.GetComponent<ItemController>().hasItem(keycard)) {
			activate.GetComponent<Laser>().turnOff();
		}
	}
}
