using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    [SerializeField] GameObject[] availiableMonsters;

    private int poolSize = 5;
    private Queue<GameObject> monsterPool = new Queue<GameObject>();

    private GameObject tempObj;

    private void Start()
    {
        InitialisePool();
    }

    void InitialisePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            tempObj = Instantiate(availiableMonsters[Random.Range(0, availiableMonsters.Length)], transform.position, transform.rotation);
            tempObj.SetActive(false);
            monsterPool.Enqueue(tempObj);

            tempObj = null;
        }
    }

    public void SpawnMonster()
    {
        tempObj = monsterPool.Peek();

        if (!tempObj.activeSelf)
        {
            tempObj = monsterPool.Dequeue();
            tempObj.SetActive(true);

            monsterPool.Enqueue(tempObj);
        }
    }
}
