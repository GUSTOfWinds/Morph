using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
	public int movementSpeed = 10;
	public float turnTime = .1f;
	public Joystick joystick;

	private Rigidbody rb;
	private GameObject startObject;
	private float turnVelocity;
	private bool canMove;
	private TouchPhase touchPhase; //Don't remove!

	private void Start() {
		canMove = true;
		touchPhase = TouchPhase.Ended;
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		SelectObject();
	}

	private void FixedUpdate() {
		if(canMove) {
			Vector3 velocity = new Vector3(joystick.Horizontal, 0, joystick.Vertical).normalized;
			if(velocity.magnitude >= .1f) {
				float targetAngle = Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg;
				float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnTime);
				transform.rotation = Quaternion.Euler(0, targetAngle, 0);
				gameObject.GetComponent<CharacterController>().Move(velocity * movementSpeed * Time.deltaTime);
			}
		}
	}

	public bool toggleMovement() {
		return canMove ? canMove = false : canMove = true;
	}

	//Bug: Using the joystick with object behind causes player to select that object. 
	//Additional bug: Using the previous method can invert the toggle movement and allow movement of player whilst morphed.
	//Additional bug: Using the previous method can allow the player the climb on top of the guard.
	private void SelectObject() {
		bool isMorphed = gameObject.GetComponent<MorphController>().isMorphed();
		//For PC
		/*if(Input.GetMouseButtonDown(0) && !isMorphed) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 30f);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				//Debug.Log("Ray hit: " + hit.transform.name + ".");
				if(hit.collider != null && hit.transform.tag.Equals("MorphableObject")) {
					toggleMovement();
					GameObject selectedObject = hit.transform.gameObject;
					//Debug.Log("Selected: " + selectedObject + ".");
					gameObject.GetComponent<MorphController>().morphObject(selectedObject);
				}
			}
		} else if(Input.GetMouseButtonDown(0) && gameObject.GetComponent<MorphController>().isMorphed().Equals(true)) {
			gameObject.GetComponent<MorphController>().morphObject();
			toggleMovement();
		}*/

		//For touch, uncomment for release!
		//sauce: https://answers.unity.com/questions/1126621/best-way-to-detect-touch-on-a-gameobject.html
		if(Input.touchCount > 0 && Input.GetTouch(0).phase.Equals(touchPhase) && !isMorphed) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 30f);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				//Debug.Log("Ray hit: " + hit.transform.name + ".");
				if(hit.collider != null && hit.transform.tag.Equals("MorphableObject")) {
					toggleMovement();
					GameObject selectedObject = hit.transform.gameObject;
					//Debug.Log("Morphing into: " + selectedObject + ".");
					gameObject.GetComponent<MorphController>().morphObject(selectedObject);
				}
			}
		} else if(Input.GetMouseButtonDown(0) && gameObject.GetComponent<MorphController>().isMorphed().Equals(true)) {
			gameObject.GetComponent<MorphController>().morphObject();
			toggleMovement();
		}
	}
}
