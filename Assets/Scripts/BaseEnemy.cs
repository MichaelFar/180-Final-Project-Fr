using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;

    private bool reachedPlayer = false;

    private float nextFire = 0.0f;

    private float fireRate = 1.0f;
    
    public float speed = 10.0f;

    public GameObject projectile;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyPerimeter>())
        {
            reachedPlayer = true;
        }
    }
    private void FireProjectile()
    {
        var projectileInstance = Instantiate(projectile);
        projectileInstance.transform.position = transform.position;
        projectileInstance.GetComponent<Bullet>().owner = gameObject;
        projectileInstance.GetComponent<Bullet>().direction = new Vector3(target.transform.position.x, 1.0f, target.transform.position.z);
    }
}
