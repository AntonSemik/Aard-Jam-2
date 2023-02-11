using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] float dayLengthSeconds = 10;
    [SerializeField] float nightLengthSeconds = 60;

    public delegate void OnDayStart();
    public static OnDayStart dayStart;
    public delegate void OnNightStart();
    public static OnNightStart nightStart;

    private bool isNight = false;
    private float cycleTimer;

    private void Start()
    {
        isNight = false;
        cycleTimer = dayLengthSeconds;
    }

    private void Update()
    {
        cycleTimer -= Time.deltaTime;

        if(cycleTimer <= 0)
        {
            ChangeDayNight();
        }
    }

    private void ChangeDayNight()
    {
        if (isNight)
        {
            StartDay();
        } else
        {
            StartNight();
        }
    }

    private void StartDay()
    {
        cycleTimer = dayLengthSeconds;

        if (dayStart != null) dayStart();
    }

    private void StartNight()
    {
        cycleTimer = nightLengthSeconds;

        if (nightStart != null) nightStart();
    }
}
