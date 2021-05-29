using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour{
	private GameObject laserBeams;

	private void Start() {
		laserBeams = gameObject.transform.GetChild(0).gameObject;
	}

	private void OnTriggerEnter(Collider collider) {
		if(collider.tag.Equals("Player")) {
			SceneManager.LoadSceneAsync("Game Over"); //Anv�nder Async eftersom Unity p�st�r att det �r b�ttre. https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html
		}
	}

	public bool turnOff() {
		toggleLighting();
		gameObject.SetActive(false);
		return true;
	}
	public bool turnOn() {
		toggleLighting();
		gameObject.SetActive(true);
		return true;
	}
	public bool toggle() {
		gameObject.SetActive(gameObject.activeSelf.Equals(true) ? false : true);
		return true;
	}

	private void toggleLighting() {
		
	}
}
