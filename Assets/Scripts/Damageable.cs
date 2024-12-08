using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    // Start is called before the first frame update

    public int MaxHealth = 1;

    private int health = 1;

    UnityEvent DamageTaken;

    UnityEvent Died;

    public GameObject objectToDestroy; 

    private void Start()
    {
        MaxHealth = WaveSingleton.enemyHealthModifier + MaxHealth;
        health = MaxHealth;
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
            }
        }

    }
}
