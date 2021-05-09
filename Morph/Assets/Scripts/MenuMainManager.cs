using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuMainManager : MonoBehaviour
{

    //These gameObjects are the parents of all the things that each menu sub-section contains
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject creditsMenu;

    //This is for connecting the exposed main mixer to the slider in the settings
    public AudioMixer masterMixer;

    //This ensures the correct menu sub-section is the active one when the scene begins
    void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        //SPACE: For a music player to play music
    }

    //This loads the next scene in the queue
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    //These 3 methods enable/disable different parts of the menu as the user clicks through them
    public void loadMain()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
    public void LoadSettings()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void LoadCredits()
    {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    //These methods have to do with controlling various aspects of the options/settings menu
    public void SetVolume(float volume)
    {
        masterMixer.SetFloat("MasterVolume", volume);
    }
    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex, true);
        Debug.Log("setQuality Called" + qualityIndex);
    }
}