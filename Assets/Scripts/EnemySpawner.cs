using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject EnemyToSpawn;
    public GameObject SpawnLocation;
    public GameObject target;


    public float WaveTime = 10.0f;
    void Start()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartSpawning()
    {
        InvokeRepeating("SetRandomRotation", 2.0f, 1.0f);
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }


    private void SetRandomRotation()
    {
        var randomRotation = Random.rotation.y;
        var rotationCopy = transform.rotation;
        rotationCopy.y = randomRotation;
        transform.rotation = rotationCopy;
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
       var enemyInstance = Instantiate(EnemyToSpawn, SpawnLocation.transform.position, Quaternion.identity);
       enemyInstance.GetComponent<BaseEnemy>().target = target;
    }


}
