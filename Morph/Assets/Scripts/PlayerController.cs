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
		SelectedObject();
	}

	private void FixedUpdate() {
		if(canMove) {
			Vector3 velocity = new Vector3(joystick.Horizontal, 0, joystick.Vertical).normalized;
			//rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime * speedMultiplier);
			//rb.AddForce(velocity);
			if(velocity.magnitude >= .1f) {
				float targetAngle = Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg;
				float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnTime);
				transform.rotation = Quaternion.Euler(0, targetAngle, 0);
				gameObject.GetComponent<CharacterController>().Move(velocity * movementSpeed * Time.deltaTime);
				
			}
			//gameObject.transform.rotation = Quaternion.LookRotation(velocity);
			//gameObject.transform.Translate(velocity * movementSpeed * Time.deltaTime, Space.World);
		}
	}

	public bool toggleMovement() {
		return canMove ? canMove = false : canMove = true;
	}

	private void OnCollisionEnter(Collision collision) {
		Debug.DrawRay(collision.contacts[0].point, collision.contacts[0].normal, Color.white);
		Debug.Log("Collision!");
	}

	private void SelectedObject() {
		bool isMorphed = gameObject.GetComponent<MorphManager>().isMorphed().Equals(false);
		//For mouse
		if(Input.GetMouseButtonDown(0) && isMorphed) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 30f);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				//Debug.Log("Ray hit: " + hit.transform.name + ".");
				if(hit.collider != null && hit.transform.tag.Equals("MorphableObject")) {
					toggleMovement();
					GameObject selectedObject = hit.transform.gameObject;
					//Debug.Log("Selected: " + selectedObject + ".");
					gameObject.GetComponent<MorphManager>().morphObject(selectedObject);
				}
			}
		} else if(Input.GetMouseButtonDown(0) && gameObject.GetComponent<MorphManager>().isMorphed().Equals(true)) {
			gameObject.GetComponent<MorphManager>().morphObject();
			toggleMovement();
		}

		//For touch, uncomment for release!
		//sauce: https://answers.unity.com/questions/1126621/best-way-to-detect-touch-on-a-gameobject.html
		/*if(Input.touchCount > 0 && Input.GetTouch(0).phase.Equals(touchPhase) && gameObject.GetComponent<Morph>().isMorphed().Equals(false)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 30f);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				//Debug.Log("Ray hit: " + hit.transform.name + ".");
				if(hit.collider != null && hit.transform.tag.Equals("MorphableObject")) {
					toggleMovement();
					GameObject selectedObject = hit.transform.gameObject;
					//Debug.Log("Morphing into: " + selectedObject + ".");
					gameObject.GetComponent<Morph>().morphObject(selectedObject);
				}
			}
		} else if(Input.GetMouseButtonDown(0) && gameObject.GetComponent<Morph>().isMorphed().Equals(true)) {
			gameObject.GetComponent<Morph>().morphObject();
			toggleMovement();
		}*/
	}
}
