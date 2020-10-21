using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Load "Main menu scene"
    public void PlayGame()
    {
        SceneManager.LoadScene("MainMenu");
    } // function - PlayGame()
    
    // Exit the game
    public void doExitGame() {
        Application.Quit();
    }
}
