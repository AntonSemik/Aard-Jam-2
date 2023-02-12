using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSphere : MonoBehaviour
{
    public int dashDamage = 15;
    IsKillable tempKillable;

    private void OnTriggerEnter(Collider other)
    {
        tempKillable = other.GetComponent<IsKillable>();

        if (tempKillable != null)
        {
            tempKillable.TakeDamage(dashDamage, 2);
        }

        tempKillable = null;
    }
}
