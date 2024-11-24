using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Vector3 startPos;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position + Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(transform.position + Vector3.right * speed * Time.deltaTime);
        }

        
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(transform.position + Vector3.forward * speed * Time.deltaTime); 
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(transform.position + Vector3.back * speed * Time.deltaTime);
        }
    }
}
