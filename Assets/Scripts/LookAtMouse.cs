using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject objectToLook;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objectToLook.transform.LookAt(WaveSingleton.Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 19.52f)));
    }
}
