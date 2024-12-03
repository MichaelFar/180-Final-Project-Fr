using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;

    private bool reachedPlayer = false;

    public float speed = 10.0f;

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
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyPerimeter>())
        {
            reachedPlayer = true;
        }
    }
}
