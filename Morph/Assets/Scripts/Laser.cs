using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour{
	private GameObject laserBeams;
	private bool laserActive = true;

	private void Start() {
		laserBeams = gameObject.transform.GetChild(0).gameObject;
	}

	private void OnTriggerEnter(Collider collider) {
		if(collider.tag.Equals("Player") && laserActive) {
			SceneManager.LoadSceneAsync("Game Over"); //Använder Async eftersom Unity påstår att det är bättre. https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html
		}
	}

	public bool turnOff() {
		foreach(Transform child in transform) {
			child.gameObject.SetActive(false);
		}
		laserActive = false;
		gameObject.GetComponent<AudioSource>().Stop();
		return true;
	}
	public bool turnOn() {
		foreach(Transform child in transform) {
			child.gameObject.SetActive(true);
		}
		laserActive = true;
		gameObject.GetComponent<AudioSource>().Play();
		return true;
	}
	public bool toggle() {
		foreach(Transform child in transform) {
			child.gameObject.SetActive(gameObject.activeSelf.Equals(true) ? false : true);
		}
		laserActive = laserActive ? false : true;
		if(laserActive) {gameObject.GetComponent<AudioSource>().Play();} 
		else if(!laserActive) {gameObject.GetComponent<AudioSource>().Stop();}
		return true;
	}
}
