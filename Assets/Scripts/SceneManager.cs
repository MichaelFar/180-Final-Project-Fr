using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//  Will handle scene transition.

/// Author: Kat Heaps
/// Date: 12/11/24
/// Description: Handles transitions to new scenes from the UI
public class GameOverScreen : MonoBehaviour
{
    //This will quit the game in thew build.
    public void QuitGame()
    {
        Application.Quit();
    }

    // This will switch scene to desired index.
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
