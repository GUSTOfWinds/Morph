using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private bool removeObject = false;
    private bool canBeTaken = true;
    private float timer = 0f;
    private float deletionTime = 1f;

    private void Update()
    {
        if (removeObject)
        {
            timer += Time.deltaTime;
            if(timer >= deletionTime)
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider collider) {
		if(collider.gameObject.tag.Equals("Player") && canBeTaken) {

			collider.gameObject.GetComponent<ItemController>().addItem(gameObject);
            removeObject = true;
            canBeTaken = false;

            //Text Pop-Up
            //Particle Effects
            //Audio Effects
		}
	}
}
