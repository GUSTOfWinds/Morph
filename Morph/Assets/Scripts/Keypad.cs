using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour{
	public GameObject player;
	public GameObject keycard;
	public GameObject laser;
	private void OnTriggerEnter(Collider collider) {
		if(collider.transform.tag.Equals(player.tag) && player.GetComponent<ItemController>().hasItem(keycard)) {
			laser.GetComponent<Laser>().turnOff();
		}
	}
}
