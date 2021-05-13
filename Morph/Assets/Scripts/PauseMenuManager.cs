using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{

    public static bool isGamePaused = false;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject playerController;

    //This ensures the game is not paused when the scene begins
    private void Start()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        isGamePaused = false;
    }

    //These three methods are tied to buttons and fulfill all the functions of the menu, both actually pausing the game as well as enabling/disabling elements or changing scenes
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        playerController.SetActive(true);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        playerController.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        pauseMenu.SetActive(false);
        pauseButton.SetActive(false);
    }
}