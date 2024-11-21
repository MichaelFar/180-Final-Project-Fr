using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Vector3 startPos;
    private PlayerShoot playerShoot;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
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
            if (playerShoot != null)
            {
                playerShoot.movingLeft = true;
            }
        }
        else if (Input.GetKey(KeyCode.D))

        {

            rb.MovePosition(transform.position + Vector3.right * speed * Time.deltaTime);
            if (playerShoot != null)
            {
                playerShoot.movingLeft = false;
            }
        }

        
    }
}
