using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class testScript : MonoBehaviour
{
    public Text myText;
    public TextMeshProUGUI myCoolText;
    // Start is called before the first frame update
    void Start()
    {
        myText = gameObject.GetComponent<Text>();
        myCoolText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
