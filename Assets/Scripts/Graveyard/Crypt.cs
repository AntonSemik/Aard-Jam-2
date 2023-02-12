using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crypt : MonoBehaviour
{
    public GameObject monster;

    public int activeFromNight = 0;
    bool isActive = false;

    void Awake()
    {
        DayNightCycle.updateNightCountUI += CheckNight;
    }

    void Start()
    {
        monster = Instantiate(monster, transform.position, transform.rotation);
        monster.SetActive(false);
    }

    void OnDestroy()
    {
        DayNightCycle.updateNightCountUI -= CheckNight;
    }

    void CheckNight(int night)
    {
        if (night >= activeFromNight)
        {
            isActive = true;
        }
    }

    public bool SpawnMonster()
    {
        if (!isActive || monster.activeSelf) return false;

        monster.transform.position = transform.position;
        monster.SetActive(true);

        return true;
    }

}
