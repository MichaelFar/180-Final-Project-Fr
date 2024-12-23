using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Shahzad, Sanaa and Michael Farrar
 * 12/9/24
 * Collects score
 * */

public class Collect_Script : MonoBehaviour
{
    public int score; //for the score script and the collection of diamonds
    // Start is called before the first frame update
    void Start()
    {
        //Allows the player to communicate with score
        WaveSingleton.playerScoreObject = this;
        score = WaveSingleton.persistentScore;
    }

    // Update is called once per frame
    void Update()
    {
        WaveSingleton.persistentScore = score;
    }
    /// <summary>
    /// Increments score and destroys self
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other) //in regards to touching the Diamonds and updating the score as well as destroying upon touch
    {

        if (other.GetComponent<Score_Script>())
        {
            score += other.GetComponent<Score_Script>().Diamonds;
            
            Destroy(other.gameObject);
        }
    }
}
