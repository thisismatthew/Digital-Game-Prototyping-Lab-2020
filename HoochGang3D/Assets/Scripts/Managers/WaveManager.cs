using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWaveIndex = 0; //start at -1 so that this always accurately refers to the correct wave
    public GameObject enemyPrefab;
    //public Vector3 spawnOffset = new Vector3(3.2f, 1.8f, 2.6f);
    public Wave[] waves;
    private bool noMoreWaves = false;
    public TurnManager tm;

    public void Start()
    {
        foreach(Wave w in waves)
        {
            w._enemyPrefab = enemyPrefab;
        }
    }

    public void SpawnCurrentWave()
    {
        FindObjectOfType<AudioManager>().Play("Wave_Begin_1");
        Vector3 spawnpoint;
        GameObject addedCharacter;
        foreach(Node n in waves[currentWaveIndex].startingNodes)
        {
            spawnpoint = n.transform.position;
            addedCharacter = (Instantiate(waves[currentWaveIndex]._enemyPrefab, spawnpoint, Quaternion.identity)); //spawn an enemy for each 
            tm.adventurers.Add(addedCharacter);
        }

        if(currentWaveIndex+1 >= waves.Length)
        {
            noMoreWaves = true;
        }
    }

    public Wave GetCurrentWave()
    {
        return waves[currentWaveIndex];
    }

    public void NextWave()
    {
        currentWaveIndex++;
    }

    public bool NoMoreWaves()
    {
        return noMoreWaves;
    }
}
