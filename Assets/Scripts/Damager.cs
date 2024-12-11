using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// Author: Michael Farrar
/// Date: 12/11/24
/// Description: This class causes damage to the 'Damageable' script
public class Damager : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 1;

    public GameObject owner;//Used to determine the source of damage

    private IEnumerator coroutine;

    UnityEvent DealtDamage;
    //Sets the proper damage of the bullets based on difficulty and player stats
    void Start()
    {
        if(owner.GetComponent<BaseEnemy>())
        {
            print("I am an enemy bullet");
            damage = WaveSingleton.enemyDamageModifier + damage;
        }
        else
        {
            damage = WaveSingleton.playerDamage;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Starts a coroutine that runs in the next frame to calculate damage, we wait because owner must be set or self damage will occur
    
    private void OnTriggerEnter(Collider other)
    {
        coroutine = damageOnTrigger(other);
        StartCoroutine(coroutine);
    }
    /// <summary>
    /// Damages the damageable on trigger, checks for owner and prevents friendly fire if an enemy
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    IEnumerator damageOnTrigger(Collider other)
    {
        yield return new WaitForEndOfFrame();

        var damageable = other.gameObject.GetComponent<Damageable>();

        var sameEnemyTeam = other.gameObject.GetComponent<BaseEnemy>() && owner.GetComponent<BaseEnemy>();

        print("Owner is " + owner + " and gameObject is ");

        if (damageable)
        {
            if (owner != other.gameObject && !sameEnemyTeam)
            {
                Destroy(gameObject);
                damageable.TakeDamage(damage);
            }
        }
        
        
    }
}
