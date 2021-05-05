using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
	public GameObject door;

	private void OnTriggerEnter(Collider collider) {
		door.GetComponent<DoorController>().OpenDoor();
	}
}
