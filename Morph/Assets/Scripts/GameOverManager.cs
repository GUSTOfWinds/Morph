using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    void Start()
    {
        //Play Game Over Audio
        //Play Game Over Particle Effects/VFX
        //Play other things that happen on a game over
        Invoke("LoadMainMenu", 5.0f);
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}