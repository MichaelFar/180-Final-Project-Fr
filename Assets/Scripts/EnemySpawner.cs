using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.AI;
/// Author: Michael Farrar
/// Date: 12/11/24
/// Description: Handles enemy spawning logic
public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject EnemyToSpawn;
    public GameObject SpawnLocation;
    public GameObject target;
    //We need the game camera because where the enemy spawns is based on its distance from the floor plane
    private Camera GameCamera;
    //How long the wave is, initialized by WaveSingleton
    private float WaveTime = 1.0f;

    /// <summary>
    /// Initializes values from the wave singleton and to the wavesingleton, sets length of waves based on the amount of enemies to be spawned
    /// </summary>
    void Start()
    {
        WaveSingleton.WaveSpawner = gameObject;
        GameCamera = WaveSingleton.Camera;
        WaveTime = (float)WaveSingleton.enemyAmountThisWave;
        //StartSpawning();
    }
    //Makes SetRandomRotation run every 1 second and starts the countdown until the wave is done, sets doneSpawning to false so enemies don't increase the difficulty early
    public void StartSpawning()
    {
        WaveSingleton.doneSpawning = false;
        InvokeRepeating("SetRandomRotation", 0.0f, 1.0f);
        StartCoroutine("WaveTimerCoroutine");
    }
    //Cancels the invoke repeating of SetRandomRotation
    public void StopSpawning()
    {
        //WaveSingleton.isInDanger = false;
        CancelInvoke();
    }

    //Randomly rotates the spawnlocation based on the larger aspect of the camera, also calls spawn enemy
    private void SetRandomRotation()
    {
        var randomRotation = Random.rotation.y;
        var rotationCopy = transform.rotation;
        rotationCopy.y = randomRotation;
        transform.rotation = rotationCopy;
        var direction = target.transform.position - SpawnLocation.transform.position;
        direction.Normalize();
        
        var largerAspect = WaveSingleton.Camera.pixelWidth > WaveSingleton.Camera.pixelHeight ? WaveSingleton.Camera.pixelWidth : WaveSingleton.Camera.pixelHeight;

        var cameraExtentWorldpoint = WaveSingleton.Camera.ScreenToWorldPoint(new Vector3(largerAspect, 0, WaveSingleton.Camera.transform.position.y));
        //- target.transform.position;

        print("Magnitude of the extent world point is " + cameraExtentWorldpoint.magnitude);

        direction.x *= cameraExtentWorldpoint.magnitude / 1.0f;
        direction.z *= cameraExtentWorldpoint.magnitude / 1.0f;

        SpawnLocation.transform.position = new Vector3(direction.x, SpawnLocation.transform.position.y, direction.z);
        SpawnEnemy();
    }
    /// <summary>
    /// Spawns the enemy
    /// </summary>
    private void SpawnEnemy()
    {
       
       var enemyInstance = Instantiate(EnemyToSpawn, SpawnLocation.transform.position, transform.rotation);
       enemyInstance.GetComponent<BaseEnemy>().target = target;

    }
    /// <summary>
    /// Ends the wave 
    /// </summary>
    /// <returns></returns>
    IEnumerator WaveTimerCoroutine()
    {
        
        // Start function WaitAndPrint as a coroutine
        yield return new WaitForSeconds(WaveTime);
        StopSpawning();
        WaveSingleton.doneSpawning = true;
    }


}
