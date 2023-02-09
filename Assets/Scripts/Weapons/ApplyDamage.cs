using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] bool disableAfterHitting = false;

    IsKillable tempKillable;

    private void OnTriggerEnter(Collider other)
    {
        tempKillable = other.GetComponent<IsKillable>();

        if (tempKillable != null)
        {
            tempKillable.TakeDamage(damage);
        }

        tempKillable = null;

        if(disableAfterHitting) gameObject.SetActive(false);
    }
}
