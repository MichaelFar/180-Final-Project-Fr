using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
 * Author: [Heaps, Kat]
 * Last Updated: [10/5/24]
 * [Will handle UI]
 */

public class UIManager : MonoBehaviour
{

    


    public TMP_Text scoreText;

    public TMP_Text livesText;


    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// Score display.
    /// </summary>
    void Update()
    {
      //scoreText.text = "Score: " + Player.Score;
      //livesText.text = "Lives: " + Player.lives;
    }
}