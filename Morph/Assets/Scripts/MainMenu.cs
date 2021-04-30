using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Methods below are called via buttons in the Main Menu, depending on which button the user clicks, a different method is called
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application.Quit does not function within the editor, so here is a debug message instead.");
    }
}