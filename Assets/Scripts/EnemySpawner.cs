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

    private float WaveTime = 1.0f;

    
    void Start()
    {
        WaveSingleton.WaveSpawner = gameObject;
        GameCamera = WaveSingleton.Camera;
        WaveTime = (float)WaveSingleton.enemyAmountThisWave;
        //StartSpawning();
    }

    public void StartSpawning()
    {
        InvokeRepeating("SetRandomRotation", 0.0f, 1.0f);
        StartCoroutine("WaveTimerCoroutine");
    }

    public void StopSpawning()
    {
        WaveSingleton.isInDanger = false;
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

        var largerAspect = WaveSingleton.Camera.pixelWidth > WaveSingleton.Camera.pixelHeight ? WaveSingleton.Camera.pixelWidth : WaveSingleton.Camera.pixelHeight;

        var cameraExtentWorldpoint = WaveSingleton.Camera.ScreenToWorldPoint(new Vector3(largerAspect, 0, 19.52f));
        //- target.transform.position;

        print("Magnitude of the extent world point is " + cameraExtentWorldpoint.magnitude);

        direction.x *= cameraExtentWorldpoint.magnitude / 1.0f;
        direction.z *= cameraExtentWorldpoint.magnitude / 1.0f;

        SpawnLocation.transform.position = new Vector3(direction.x, SpawnLocation.transform.position.y, direction.z);
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
