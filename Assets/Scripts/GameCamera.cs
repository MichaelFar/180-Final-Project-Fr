using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WaveSingleton.Camera = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    
}
