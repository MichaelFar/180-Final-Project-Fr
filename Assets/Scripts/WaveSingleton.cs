using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Author: Michael Farrar
/// Date: 12/11/24
/// Description: Global singleton that handles wave progression and holds player stats, is called in several scripts
/// </summary>
public static class WaveSingleton
{
    // Start is called before the first frame update
    public static GameObject WaveSpawner;

    public static Camera Camera;

    public static Damageable playerDamageable;

    public static bool isInDanger = false;

    public static bool doneSpawning = true;

    public static int currentWave = 1;

    public static int enemyDamageModifier = 0;

    public static int enemyHealthModifier = 0;

    public static int playerDamage = 1;

    public static Collect_Script playerScoreObject;

    private static int _enemyCount = 10;
    public static int enemyAmountThisWave = 10;
    /// <summary>
    /// Due to strangeness, this variable no longer handles increasing difficulty
    /// </summary>
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
                
                
                increaseDifficulty();
            }
            
        }
    }

    
    //Begins the wave

    public static void beginWave()
    {
        WaveSpawner.GetComponent<EnemySpawner>().StartSpawning();
        enemyCount = enemyAmountThisWave;
    }
    //Defines how increasing difficulty occurs, called by enemies
    public static void increaseDifficulty()
    {
        currentWave += 1;
        enemyAmountThisWave += 2;
        enemyDamageModifier += 1;
        enemyHealthModifier += 1;
        //The 4th wave will send you to the next level
        if(currentWave == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    //Sets difficulty values back to their defaults, called by the player upon entering the scene
    public static void resetDifficulty()
    {

        currentWave = 1;
        enemyAmountThisWave = 10;
        enemyDamageModifier = 0;
        enemyHealthModifier = 0;
        playerDamage = 1;
        playerDamageable.health = 5;
        playerDamageable.MaxHealth = 5;
        _enemyCount = 10;
        playerDamage = 1;
        isInDanger = false;
    }

}
