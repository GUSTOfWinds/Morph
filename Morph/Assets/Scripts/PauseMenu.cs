using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject PauseMenuUI;
    public GameObject pauseButton;

    //This disables the pause menu, and enables a pause button, to match the games starting unpaused state.
    private void Start()
    {
        PauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //This either resumes, or pauses the game, based on it's current state.
            //This function is also tied to a button thats visable when the game is active in the topright, in addition to the escape key
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    //These functions are essentially opposites, and do opposite things, but they all interact with the same 4 variables.
    public void PauseGame()
    {
        PauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void ResumeGame()
    {
        PauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    //This function takes the player back to the main menu via a button, which is why it is not referenced in the script
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}