using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WaveSingleton
{
    // Start is called before the first frame update
    public static GameObject WaveSpawner;

    public static Camera Camera;

    public static bool isInDanger = false;

    public static int currentWave = 1;

    public static int enemyDamageModifier = 0;

    public static int enemyHealthModifier = 0;

    private static int _enemyCount = 10;


    //public static int enemyCount = 0;
    public static int enemyCount
    {
        get { return _enemyCount; }
        set
        {
            _enemyCount = value;
            if (value < 0)
            {
                MonoBehaviour.print("Ended wave");
                
                isInDanger = false;
                increaseDifficulty();
            }
            
        }
    }

    public static int enemyAmountThisWave = 10;
    public static void printhello()
    {
        MonoBehaviour.print("Hello");
    }

    public static void beginWave()
    {
        WaveSpawner.GetComponent<EnemySpawner>().StartSpawning();
        enemyCount = enemyAmountThisWave;
    }

    private static void increaseDifficulty()
    {
        currentWave += 1;
        enemyAmountThisWave += 2;
        //enemyCount = enemyAmountThisWave;
        enemyDamageModifier += 1;
        enemyHealthModifier += 1;
    }

}
