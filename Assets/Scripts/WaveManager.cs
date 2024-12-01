using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPreFab;
    public Transform[] spawnPoints;
    public int eneiesPerWave = 5; // Doðacak düþman sayýsý
    public float timeBetweenWaves = 10f; // Doðma arasý süre

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while(true)
        {
            currentWave++;

            for (int i = 0; i < eneiesPerWave; i++)
            {
                int spawnIndex = Random.Range(0, spawnPoints.Length);
                Instantiate(enemyPreFab, spawnPoints[spawnIndex].position,Quaternion.identity);
                yield return new WaitForSeconds(1);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}
