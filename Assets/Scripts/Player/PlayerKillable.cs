using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillable : IsKillable
{
    public override void Die()
    {
        Debug.Log("Player lost");

        Time.timeScale = 0f;
    }
}
