using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour{
	private void OnCollisionEnter(Collision collision) {
		if(collision.transform.tag.Equals("Player")) {
			//SceneManager.LoadScene(GameOver); //Kill player
		}
	}

	public bool turnOff() {
		gameObject.SetActive(false);
		return true;
	}
	public bool turnOn() {
		gameObject.SetActive(true);
		return true;
	}
	public bool toggle() {
		gameObject.SetActive(gameObject.activeSelf.Equals(true) ? false : true);
		return true;
	}

	private void Start() {
		Debug.Log(gameObject.name);
	}
}
