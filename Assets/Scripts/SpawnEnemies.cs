using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] float spawnDistance = 10f;
    [SerializeField] EnemyGroupTimings easyGroupTimings;
    [SerializeField] EnemyGroupTimings averageGroupTimings;
    //[SerializeField] EnemyGroupTimings hardGroupTimings;
    //[SerializeField] EnemyGroupTimings bossGroupTimings;


    [System.Serializable] public class EnemyGroupTimings
    {
        public float firstSpawnDelay;
        public float spawnRateBase;
        public float spawnAccelerationPerWave;

        [HideInInspector] public float accumulatedSpawnAcceleration;
        [HideInInspector] public float spawnTimer;
    }

    [System.Serializable] public class EnemyGroup
    {
        public GameObject[] enemiesInGroup;
    }
    [SerializeField] EnemyGroup[] easyGroups;
    [SerializeField] EnemyGroup[] averageGroups;
    [SerializeField] EnemyGroup[] hardGroups;

    private void Start()
    {
        easyGroupTimings.spawnTimer = easyGroupTimings.firstSpawnDelay;
        averageGroupTimings.spawnTimer = averageGroupTimings.firstSpawnDelay;

    }

    private void Update()
    {
        SpawnEnemyGroup(easyGroupTimings,easyGroups);
        SpawnEnemyGroup(averageGroupTimings, averageGroups);
    }

    void SpawnEnemyGroup(EnemyGroupTimings timings, EnemyGroup[] groupArray)
    {
        if (timings.spawnTimer <= 0)
        {
            SpawnEnemiesFromGroup(groupArray[Random.Range(0, groupArray.Length)]);

            timings.accumulatedSpawnAcceleration += timings.spawnAccelerationPerWave;
            timings.spawnTimer = timings.spawnRateBase;
        }
        else
        {
            timings.spawnTimer -= Time.deltaTime * (1 + timings.accumulatedSpawnAcceleration);
        }
    }

    void SpawnEnemiesFromGroup(EnemyGroup enemyGroup)
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

        return point.normalized * spawnDistance;
    }
}
