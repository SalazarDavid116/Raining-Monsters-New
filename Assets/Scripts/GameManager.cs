using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    } // function - PlayGame()
    
    // Exit the game
    public void doExitGame() {
        Application.Quit();
    }
}
