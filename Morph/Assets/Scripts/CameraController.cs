using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform target;
	public float speed = 100f;
	public Vector3 offset;


    // Update is called once per frame
    void LateUpdate()
    {
		transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
    }
}
