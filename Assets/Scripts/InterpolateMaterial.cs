using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolateMaterial : MonoBehaviour
{
    // Start is called before the first frame update
    // Blends between two materials

    public Material material1;
    public Material material2;
    public float duration = 2.0f;
    public Renderer rend;
    public bool ShouldLerp = false;

    void Start()
    {
        rend = GetComponent<Renderer> ();

        // At start, use the first material
        rend.material = material1;
    }

    void Update()
    {
        // ping-pong between the materials over the duration
        if(ShouldLerp)
        {
            BeginMaterialLerp();
        }
        
    }

    public void BeginMaterialLerp()
    {
        float lerp = Mathf.PingPong(Time.time, duration);
        rend.material.Lerp(material1, material2, lerp);
    }
}
