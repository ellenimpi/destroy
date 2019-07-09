using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;

    private void Start()
    {
        var currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEnemiesOfWave(currentWave));
    }

    private IEnumerator SpawnAllEnemiesOfWave(WaveConfig currentWave)
    {
        for (int i = 0; i < currentWave.getEnemyCount(); i++)
        {
            Instantiate(currentWave.getEnemy(), currentWave.getPath()[0].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(currentWave.getTimeBetween());
        }
    }
}
