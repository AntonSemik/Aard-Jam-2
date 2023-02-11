using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] Light dayLight;
    [SerializeField] Light nightLight;
    [SerializeField] float switchTime = 0.2f;
    [SerializeField] float maxIntencity;

    Light increasingLight;
    Light decreasingLight;

    float switchTimer;
    bool isSwitching;

    private void Start()
    {
        DayNightCycle.dayStart += SwitchToDay;
        DayNightCycle.nightStart += SwitchToNight;
    }

    private void OnDestroy()
    {
        DayNightCycle.dayStart -= SwitchToDay;
        DayNightCycle.nightStart -= SwitchToNight;
    }

    private void Update()
    {
        if (!isSwitching) return;

        switchTimer -= Time.deltaTime;



        if (switchTimer <= 0)
        {
            isSwitching = false;
        }
    }

    void SwitchToDay()
    {
        isSwitching = true;

        increasingLight = dayLight;
        decreasingLight = nightLight;
    }

    void SwitchToNight()
    {
        isSwitching = true;

        increasingLight = nightLight;
        decreasingLight = dayLight;

    }
}
