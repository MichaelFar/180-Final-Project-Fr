using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// Author: Michael Farrar
/// Date: 12/11/24
/// Description: Handles the logic for the slime enemies
public class BaseEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    //Where the enemies travel to
    public GameObject target;

    private bool reachedPlayer = false;

    private float nextFire = 0.0f;

    private float fireRate = 1.0f;

    private float scoreOdds = 3.0f;
    
    public float speed = 10.0f;
    //Enemy projectile
    public GameObject projectile;
    //Object they have a chance of dropping
    public GameObject scoreDrop;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the enemy to the target, if they reach the perimeter they begin to shoot
        if (!reachedPlayer)
        {
            var step = speed * Time.deltaTime; // calculate distance to move

            var destination = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

            transform.LookAt(destination);
        }
        else
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                FireProjectile();
            }
        }
    }
    /// <summary>
    /// Sets the value for reached player if they reach the EnemyPerimeter
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyPerimeter>())
        {
            reachedPlayer = true;
        }
    }
    /// <summary>
    /// Fires the projectile
    /// </summary>
    private void FireProjectile()
    {
        var projectileInstance = Instantiate(projectile);
        projectileInstance.transform.position = transform.position;
        projectileInstance.GetComponent<Bullet>().owner = gameObject;
        projectileInstance.GetComponent<Bullet>().direction = new Vector3(target.transform.position.x, 1.0f, target.transform.position.z);
    }
    /// <summary>
    /// Checks for other enemies in the scene, if they don't exist and the spawner is done spawning increases the wave difficulty, also rolls for drop
    /// </summary>
    private void OnDestroy()
    {
        BaseEnemy[] tests = FindObjectsOfType(typeof(BaseEnemy)) as BaseEnemy[];
        
        var roll = Random.Range(1.0f, 10.0f);
        if (tests.Length == 0 && WaveSingleton.doneSpawning)
        {
            WaveSingleton.isInDanger = false;
            WaveSingleton.increaseDifficulty();
        }
        if(roll <= scoreOdds)
        {
            var scoreObject = Instantiate(scoreDrop);
            scoreObject.transform.position = transform.position;
        }
    }
}
