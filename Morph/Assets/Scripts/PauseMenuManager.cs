using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{

    public static bool isGamePaused = false;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject playerJoystickController;
    public AudioSource audioSource;
    public AudioClip buttonSound;

    //This ensures the game is not paused when the scene begins
    private void Start()
    {
        PauseGame();
        ResumeGame();

    }

    //These three methods are tied to buttons and fulfill all the functions of the menu, both actually pausing the game as well as enabling/disabling elements or changing scenes
    public void ResumeGame()
    {
        buttonClick();
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        playerJoystickController.SetActive(true);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void PauseGame()
    {
        buttonClick();
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        playerJoystickController.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void LoadMenu()
    {
        buttonClick();
        SceneManager.LoadScene("Main Menu");
        pauseMenu.SetActive(false);
        pauseButton.SetActive(false);
    }

    public void buttonClick()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}