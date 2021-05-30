using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour{
	public Light doorLight;

	private Vector3 pos;
	private bool isClosed;

	void Start() {
		pos = gameObject.transform.position;
		isClosed = true;
	}

	void Update() {
		
	}

	public void OpenDoor() {
		FindObjectOfType<AudioManager>().Play("OpenDoor");
		isClosed = false;

		transform.position = new Vector3(pos.x + 1, pos.y + 2.5f, pos.z + 40);
		transform.Rotate(new Vector3(0, 0, -90));

		doorLight.color = Color.green;
	}

	public void CloseDoor() {
		isClosed = true;

		transform.position = new Vector3(pos.x, pos.y, pos.z);
		transform.Rotate(new Vector3(0, 0, 0));

		doorLight.color = Color.red;
	}

	public void ToggleDoor() {
		isClosed = isClosed ? false : true;

		if(isClosed) {OpenDoor();}
		else if(isClosed) {CloseDoor();}
	}

	public bool IsClosed() {
		return isClosed;
	}
}
