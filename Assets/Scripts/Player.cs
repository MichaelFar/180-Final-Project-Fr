using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public float speed;
    
    

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }



    private void PlayerMove()
    {
        Vector3 movement = Vector3.zero;

        if (!WaveSingleton.isInDanger)
        {
            if (Input.GetKey(KeyCode.A))
            {
                movement += Vector3.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movement += Vector3.right;
            }
            if (Input.GetKey(KeyCode.W))
            {
                movement += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movement += Vector3.back;
            }
            if (Input.GetKey(KeyCode.E))
            {
                WaveSingleton.isInDanger = true;
                WaveSingleton.beginWave();
            }

            if (movement != Vector3.zero)
            {
                movement.Normalize();
                rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
            }
        }
    }
    public void purchaseDamage()
    {
        if (WaveSingleton.playerScoreObject.score >= 600)
        {
            WaveSingleton.playerScoreObject.score -= 600;
            WaveSingleton.playerDamage += 1;
            
        }
        
    }
    public void purchaseHealth()
    {
        if (WaveSingleton.playerScoreObject.score >= 300)
        {
            WaveSingleton.playerScoreObject.score -= 300;
            WaveSingleton.playerDamageable.Heal(2);

        }
        
    }
    public void purchaseMaxHealth()
    {
        if (WaveSingleton.playerScoreObject.score >= 500)
        {
            WaveSingleton.playerScoreObject.score -= 500;
            WaveSingleton.playerDamageable.IncreaseMaxHealth(3);

        }
        
    }
}
