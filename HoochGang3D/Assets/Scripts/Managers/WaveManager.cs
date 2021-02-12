using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private int currentWaveIndex = 0; //start at -1 so that this always accurately refers to the correct wave
    public GameObject enemyPrefab;
    public Vector3 spawnOffset = new Vector3(3.2f, 1.8f, 2.6f);
    public Wave[] waves;
    private bool noMoreWaves = false;

    public void Start()
    {
        foreach(Wave w in waves)
        {
            w._enemyPrefab = enemyPrefab;
        }
    }

    public void SpawnCurrentWave()
    {
        Vector3 spawnpoint;
        foreach(Node n in waves[currentWaveIndex].startingNodes)
        {
            spawnpoint = n.transform.position + spawnOffset;
            Instantiate(waves[currentWaveIndex]._enemyPrefab, spawnpoint, Quaternion.identity); //spawn an enemy for each 
        }
    }

    public void NextWave()
    {
        currentWaveIndex++;
    }

    public bool NoMoreWaves()
    {
        return waves[currentWaveIndex] == null; //if the wave index is greater than or equal to the number of waves, the game is over
    }
}
