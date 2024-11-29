using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

//  Will handle scene transition.


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
