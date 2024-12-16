using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
/// Author: Michael Farrar, Kat Heaps
/// Date: 12/11/24
/// Description: Handles player movement and player upgrade purchasing
public class Player : MonoBehaviour
{
    
    public float speed;


    public int damageButtonValue = 600;
    public int healButtonValue = 300;
    public int maxHealthButtonValue = 500;
    public int gemModButtonValue = 450;
    private Rigidbody rb;

    /// <summary>
    /// When the player enters the scene, reset difficulty to wave 1
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        WaveSingleton.player = this;

        if(WaveSingleton.currentLevelIndex == SceneManager.GetActiveScene().buildIndex)
        {
            print("Restarting with default difficulty");
            WaveSingleton.restartDifficulty();
        }
        else
        {
            WaveSingleton.resetDifficulty();
        }
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

                if (WaveSingleton.currentWave > 5)
                {
                    if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1) != null)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }

                }
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
        if (WaveSingleton.playerScoreObject.score >= damageButtonValue)
        {
            WaveSingleton.playerScoreObject.score -= damageButtonValue;
            WaveSingleton.playerDamage += 1;
            damageButtonValue += 350;
        }
        
    }
    /// <summary>
    /// Heals the player if they have enough points
    /// </summary>
    public void purchaseHealth()
    {
        if (WaveSingleton.playerScoreObject.score >= healButtonValue)
        {
            WaveSingleton.playerScoreObject.score -= healButtonValue;
            WaveSingleton.playerDamageable.Heal(2);

        }
        
    }
    /// <summary>
    /// Increases the player's max health and heals them by that amount
    /// </summary>
    public void purchaseMaxHealth()
    {
        if (WaveSingleton.playerScoreObject.score >= maxHealthButtonValue)
        {
            WaveSingleton.playerScoreObject.score -= maxHealthButtonValue;
            WaveSingleton.playerDamageable.IncreaseMaxHealth(3);
            WaveSingleton.playerDamageable.Heal(3);
            maxHealthButtonValue += 450;
        }
        
    }
    public void upgradeGems()
    {
        if (WaveSingleton.playerScoreObject.score >= gemModButtonValue)
        {
            WaveSingleton.playerScoreObject.score -= gemModButtonValue;
            WaveSingleton.gemValueMod += 150;
            gemModButtonValue += 350;
        }
    }
}
