using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Shahzad, Sanaa
 * 12/2/24
 * Moves player from one location to another
 * */

public class Portal : MonoBehaviour
{
    public GameObject spawnPoint;

    
    private void OnTriggerEnter(Collider other)
    {
        var isPlayer = other.GetComponent<Player>();
        var isEnemy = other.GetComponent<BaseEnemy>();
        if (isPlayer || isEnemy)
        {
            other.transform.position = spawnPoint.transform.position;
        }
       
    }
}
