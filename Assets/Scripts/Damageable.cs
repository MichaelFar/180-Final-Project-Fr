using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Damageable : MonoBehaviour
{
    // Start is called before the first frame update

    public int MaxHealth = 1;

    public int health = 1;

    UnityEvent DamageTaken;

    UnityEvent Died;

    public GameObject objectToDestroy; 

    private void Start()
    {
        MaxHealth = WaveSingleton.enemyHealthModifier + MaxHealth;
        health = MaxHealth;
        if(gameObject.GetComponent<Player>())
        {
            WaveSingleton.playerDamageable = this;
        }
    }
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
                SceneManager.LoadScene(2);
            }
        }

    }
    public void Heal(int amountToHeal)
    {
        health = Mathf.Clamp(health + amountToHeal, 0, MaxHealth);
    }
    public void IncreaseMaxHealth(int amountToIncrease)
    {
        MaxHealth += amountToIncrease;
    }
}
