using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    public GameObject monster;

    public int activeFromNight = 0;
    protected bool isActive = false;

    protected void Awake()
    {
        DayNightCycle.updateNightCountUI += CheckNight;
    }

    protected void Start()
    {
        monster = Instantiate(monster, transform.position, transform.rotation);
        monster.SetActive(false);
    }
    protected void OnDestroy()
    {
        DayNightCycle.updateNightCountUI -= CheckNight;
    }

    protected void CheckNight(int night)
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
