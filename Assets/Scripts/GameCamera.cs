using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// Author: Michael Farrar
/// Date: 12/11/24
/// Description: Merely initializes the game camera in the wavesingleton
/// </summary>
public class GameCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WaveSingleton.Camera = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    
}
