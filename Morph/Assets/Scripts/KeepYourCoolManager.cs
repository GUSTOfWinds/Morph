using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepYourCoolManager : MonoBehaviour
{
    private bool playerSucceeded;
    public AudioSource theMusic;
    public bool startPlaying;
    public StressScroller scroller;
    public static KeepYourCoolManager instance;
    public int currentScore;
    public int targetScore;
    public int scorePerNote;
    public GameObject gameOverText;
    public GameObject gameOverPanel;
    public GameObject successText;
    public GameObject successPanel;
    public float duration;
    public string lastScene;

    // Start is called before the first frame update
    //This ensures that all the UI objects tied to the player winning or losing the mini game are not active when the scene begins
    void Start()
    {
        instance = this;
        gameOverPanel.SetActive(false);
        gameOverText.SetActive(false);
        successPanel.SetActive(false);
        successText.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                scroller.hasBegun = true;
                theMusic.Play();
                Invoke("SuccessOrFail", duration);
            }
        }
    }
    public void NoteHit()
    {
        Debug.Log("Stress Hit");
        currentScore += scorePerNote;
    }
    public void noteMissed()
    {
        Debug.Log("Stress Missed");
    }
    //This checks if the player succeeded, or failed, and automatically happens after the minigame begins, after a set duration
    public void SuccessOrFail()
    {
        Debug.Log("Invoke Successful");
        if (currentScore < targetScore)
        {
            Debug.Log("Keep Your Cool: Failed.");
            theMusic.Stop();
            gameOverPanel.SetActive(true);
            gameOverText.SetActive(true);
            playerSucceeded = false;
            Invoke("ExitKeepYourCool", 3.0f);
        }
        else
        {
            Debug.Log("Keep Your Cool: Succeeded.");
            theMusic.Stop();
            successPanel.SetActive(true);
            successText.SetActive(true);
            playerSucceeded = true;
            Invoke("ExitKeepYourCool", 3.0f);
        }
    }
    //This takes the player from their current scene, into the KeepYourCool minigame. A function like this will most likley exist on the [Dog]-type gameObject, but its functionality exists here
    //as well, so that it can be copied over later when that aspect of the game is actually completed.
    public void LoadKeepYourCool()
    {
        lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("KeepYourCool");
    }
    //CODE SPACE: Trim these methods with parent/child directories in unity at a later date, instead of calling 4 seperate things at once
    public void ExitKeepYourCool()
    {
        if (playerSucceeded)
        {
            gameOverPanel.SetActive(false);
            gameOverText.SetActive(false);
            successPanel.SetActive(false);
            successText.SetActive(false);
            SceneManager.LoadScene(lastScene);
        }
        if (playerSucceeded == false)
        {
            gameOverPanel.SetActive(false);
            gameOverText.SetActive(false);
            successPanel.SetActive(false);
            successText.SetActive(false);
            SceneManager.LoadScene(lastScene);
        }
    }
}