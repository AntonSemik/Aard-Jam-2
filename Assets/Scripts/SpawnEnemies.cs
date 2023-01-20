using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] float firstSpawnDelay = 3f;
    [SerializeField] float spawnRateBase = 10f;
    [SerializeField] float spawnAccelerationPerWave = 0.1f;
    float accumulatedSpawnAcceleration;
    float spawnTimer = 0;

    [System.Serializable] public class EnemyGroup
    {
        public GameObject[] enemiesInGroup;
    }
    [SerializeField] EnemyGroup[] easyGroups;
    [SerializeField] EnemyGroup[] averageGroups;
    [SerializeField] EnemyGroup[] hardGroups;

    private void Start()
    {
        spawnTimer = firstSpawnDelay;
    }

    private void Update()
    {
        if (spawnTimer <= 0)
        {
            SpawnEnemyGroup(easyGroups[Random.Range(0, easyGroups.Length)]);

            accumulatedSpawnAcceleration += spawnAccelerationPerWave;
            spawnTimer = spawnRateBase;
        }
        else
        {
            spawnTimer -= Time.deltaTime * (1 + accumulatedSpawnAcceleration);
        }
    }

    void SpawnEnemyGroup(EnemyGroup enemyGroup)
    {
        foreach(GameObject enemy in enemyGroup.enemiesInGroup)
        {
            Instantiate(enemy, GetRandomPointOnSpawnPlane(), Quaternion.identity);
        }
    }

    Vector3 GetRandomPointOnSpawnPlane()
    {
        Vector3 point = Random.insideUnitSphere;
        point.y = 0;

        if(point == Vector3.zero)
        {
            point = Vector3.forward;
        }

        return point.normalized * ArenaSize.instance.ArenaRadius;
    }
}
