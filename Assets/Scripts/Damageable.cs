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
            WaveSingleton.enemyCount -= 1;
            if (gameObject.GetComponent<BaseEnemy>())
            {
                WaveSingleton.enemyCount -= 1;
                Destroy(objectToDestroy);
            }
        }

    }
}
