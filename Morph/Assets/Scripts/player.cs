using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour{
	public float speedMultiplier = 5.0f;
	public Joystick joystick;

	private Rigidbody rb;
	private GameObject startObject;
	private bool canMove;
	TouchPhase touchPhase; //Don't remove!

	private void Start() {
		canMove = true;
		touchPhase = TouchPhase.Ended;
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		SelectedObject();
	}

	private void FixedUpdate() {
		if(canMove) {
			Vector3 velocity = new Vector3(joystick.Horizontal, 0.0f, joystick.Vertical);
			//rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime * speedMultiplier);
			gameObject.transform.rotation = Quaternion.LookRotation(velocity).normalized;
			gameObject.transform.Translate(velocity * speedMultiplier * Time.deltaTime, Space.World);
		}
	}

	public bool toggleMovement() {
		return canMove ? canMove = false : canMove = true;
	}

	private void OnCollisionEnter(Collision collision) {
		foreach(ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
			Debug.Log("Wanker"); //The collision of the player with objects and walls doesn't work...
		}
	}

	private void SelectedObject() {
		//For mouse
		//Debug.Log("Mouse position: " + Input.mousePosition + ". Mouse 1 down: " + Input.GetMouseButtonDown(0));
		if(Input.GetMouseButtonDown(0) && gameObject.GetComponent<morph>().isMorphed().Equals(false)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 30f);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				//Debug.Log("Ray hit: " + hit.transform.name + ".");
				if(hit.collider != null && hit.transform.tag.Equals("MorphableObject")) {
					toggleMovement();
					GameObject selectedObject = hit.transform.gameObject;
					//Debug.Log("Selected: " + selectedObject + ".");
					gameObject.GetComponent<morph>().morphObject(selectedObject);
				}
			}
		}else if(Input.GetMouseButtonDown(0) && gameObject.GetComponent<morph>().isMorphed().Equals(true)) {
			gameObject.GetComponent<morph>().morphObject();
			toggleMovement();
		}

		//For touch, needs updating from For mouse part
		//sauce: https://answers.unity.com/questions/1126621/best-way-to-detect-touch-on-a-gameobject.html
		/*if(Input.touchCount > 0 && Input.GetTouch(0).phase.Equals(touchPhase)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 30f);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				Debug.Log(hit.transform.name);
				if(hit.collider != null) {
					GameObject selectedObject = hit.transform.gameObject;
					Debug.Log("Selected: " + selectedObject.name + ". Testing: " + selectedObject.transform.name);
					gameObject.GetComponent<morph>().morphObject(selectedObject.name);
				}
			}
		}*/
	}
}
