using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
/// Author: Michael Farrar
/// Date: 12/11/24
/// Description: This handles health and logic for when health runs out
/// </summary>
public class Damageable : MonoBehaviour
{
    // Start is called before the first frame update

    public int MaxHealth = 1;

    public int health = 1;

    UnityEvent DamageTaken;

    UnityEvent Died;

    public GameObject objectToDestroy; 
    /// <summary>
    /// Sets health based on the difficulty for the enemies and initializes health to be max health, sets the reference to the player damageable in the singleton
    /// </summary>
    private void Start()
    {
        MaxHealth = WaveSingleton.enemyHealthModifier + MaxHealth;
        health = MaxHealth;
        if(gameObject.GetComponent<Player>())
        {
            WaveSingleton.playerDamageable = this;
        }
    }
    /// <summary>
    /// Contains logic for taking damage, goes to the game over screen if the player loses all their health
    /// </summary>
    /// <param name="damageToTake"></param>
    public void TakeDamage(int damageToTake)
    {

        health = Mathf.Clamp(health - damageToTake, 0, MaxHealth);

        //DamageTaken.Invoke();
        print("Taken Damage");
        if(health == 0)
        {
            //Died.Invoke();
            
            if (gameObject.GetComponent<BaseEnemy>())
            {
                Destroy(objectToDestroy);
            }
            else if(gameObject.GetComponent<Player>())
            {
                print("Player has died, put gameover code here");
                SceneManager.LoadScene(4);
                
            }
        }

    }
    /// <summary>
    /// Heals the player and clamps the value to max health
    /// </summary>
    /// <param name="amountToHeal"></param>
    public void Heal(int amountToHeal)
    {
        health = Mathf.Clamp(health + amountToHeal, 0, MaxHealth);
    }
    /// <summary>
    /// Increases max health
    /// </summary>
    /// <param name="amountToIncrease"></param>
    public void IncreaseMaxHealth(int amountToIncrease)
    {
        MaxHealth += amountToIncrease;
    }
}
