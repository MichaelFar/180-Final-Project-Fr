using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damager : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 1;

    UnityEvent DealtDamage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var playerDamageable = collision.gameObject.GetComponent<Damageable>();

        if(playerDamageable)
        {
            playerDamageable.TakeDamage(damage);
            //DealtDamage.Invoke();
        }
    }
}
