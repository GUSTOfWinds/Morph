using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour{
	public GameObject door;

	private void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag.Equals("Player")){
			collider.gameObject.GetComponent<PlayerTreasure>().treasureCollected = true;
			door.GetComponent<DoorController>().OpenDoor();
			Debug.Log("Player has picked up the treasure.");
			gameObject.SetActive(false);
		}
	}
}