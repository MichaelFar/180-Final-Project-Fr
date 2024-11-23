using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject EnemyToSpawn;
    public GameObject SpawnLocation;
    public GameObject target;

    private Camera GameCamera;

    public float WaveTime = 10.0f;
    void Start()
    {
        WaveSingleton.WaveSpawner = gameObject;
        GameCamera = WaveSingleton.Camera;
        StartSpawning();
    }

    public void StartSpawning()
    {
        InvokeRepeating("SetRandomRotation", 0.0f, 1.0f);
        StartCoroutine("WaveTimerCoroutine");
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
        var direction = target.transform.position - SpawnLocation.transform.position;
        direction.Normalize();

        var cameraExtentWorldpoint = WaveSingleton.Camera.ScreenToWorldPoint(new Vector3(WaveSingleton.Camera.scaledPixelWidth, WaveSingleton.Camera.scaledPixelHeight, SpawnLocation.transform.position.z));
        
        
        //- target.transform.position;

        direction.x = direction.x * cameraExtentWorldpoint.magnitude;
        direction.z = direction.z * cameraExtentWorldpoint.magnitude;

        SpawnLocation.transform.position = new Vector3(direction.x, SpawnLocation.transform.position.normalized.y, direction.z);
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
       
       var enemyInstance = Instantiate(EnemyToSpawn, SpawnLocation.transform.position, transform.rotation);
       enemyInstance.GetComponent<BaseEnemy>().target = target;

    }
    IEnumerator WaveTimerCoroutine()
    {
        
        // Start function WaitAndPrint as a coroutine
        yield return new WaitForSeconds(WaveTime);
        StopSpawning();

    }


}
