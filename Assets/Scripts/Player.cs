using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// Author: Michael Farrar, Kat Heaps
/// Date: 12/11/24
/// Description: Handles player movement and player upgrade purchasing
public class Player : MonoBehaviour
{
    
    public float speed;
    
    

    private Rigidbody rb;
    /// <summary>
    /// When the player enters the scene, reset difficulty to wave 1
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        WaveSingleton.resetDifficulty();
    }

    
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }


    /// <summary>
    /// Handles player movement, if the player is in danger they cannot move
    /// </summary>
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
    /// <summary>
    /// Upgrades the player's damage if they have enough points
    /// </summary>
    public void purchaseDamage()
    {
        if (WaveSingleton.playerScoreObject.score >= 600)
        {
            WaveSingleton.playerScoreObject.score -= 600;
            WaveSingleton.playerDamage += 1;
            
        }
        
    }
    /// <summary>
    /// Heals the player if they have enough points
    /// </summary>
    public void purchaseHealth()
    {
        if (WaveSingleton.playerScoreObject.score >= 300)
        {
            WaveSingleton.playerScoreObject.score -= 300;
            WaveSingleton.playerDamageable.Heal(2);

        }
        
    }
    /// <summary>
    /// Increases the player's max health and heals them by that amount
    /// </summary>
    public void purchaseMaxHealth()
    {
        if (WaveSingleton.playerScoreObject.score >= 500)
        {
            WaveSingleton.playerScoreObject.score -= 500;
            WaveSingleton.playerDamageable.IncreaseMaxHealth(3);
            WaveSingleton.playerDamageable.Heal(3);

        }
        
    }
}
