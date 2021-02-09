using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private int currentWave = 0;

    public Wave[] waves;

    public void SpawnWave()
    {
        //instantiate an enemy at each transform defined in the current wave
        foreach(Transform t in waves[currentWave].startLocations)
        {
            Instantiate(waves[currentWave].enemy, t.position, Quaternion.identity);
        }
    }

    public void NextWave()
    {
        currentWave++;
    }
}
