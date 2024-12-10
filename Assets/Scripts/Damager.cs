using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damager : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 1;

    public GameObject owner;

    private IEnumerator coroutine;

    UnityEvent DealtDamage;
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

    
    private void OnTriggerEnter(Collider other)
    {
        coroutine = damageOnTrigger(other);
        StartCoroutine(coroutine);
    }
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
