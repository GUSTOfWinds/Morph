using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    private MeshRenderer heartRenderer;
    public Material defaultMaterial;
    public Material pressedMaterial;
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        //This connects the MeshRenderer component, to the correct mesh renderer in the scene
        heartRenderer = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        //This if/if statement changes the look of the object, by altering its material, based on player input
        if (Input.GetKeyDown(keyToPress) || Input.GetMouseButtonDown(0))
        {
            heartRenderer.material = pressedMaterial;
        }
        if (Input.GetKeyUp(keyToPress) || Input.GetMouseButtonUp(0))
        {
            heartRenderer.material = defaultMaterial;
        }
    }
}