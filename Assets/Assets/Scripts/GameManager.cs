using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] _spawnPoints;
    [SerializeField]
    private GameObject[] _enemyFormations;

    private List<float> spawnTimes = new List<float> {5, 15, 20, 30, 40 };
    private int nextSpawnIndex = 0;

    void Update()
    {
        if(nextSpawnIndex < spawnTimes.Count && Time.timeSinceLevelLoad >= spawnTimes[nextSpawnIndex])
        {
            SpawnEnemy();
            nextSpawnIndex++;
        }
    }

    private void SpawnEnemy()
    {
        Debug.Log("Spawn");
        // TODO: Figure out what to spawn
    }
}
