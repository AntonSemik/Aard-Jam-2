using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float startVelocity;

    [SerializeField] int damage = 10;

    [SerializeField] float lifeTime = 3f;
    float timeLeft;

    [SerializeField] Rigidbody RB;

    IsKillable tempKillable;

    private void OnEnable()
    {
        RB.velocity = transform.forward * startVelocity;
        timeLeft = lifeTime;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        tempKillable = other.GetComponent<IsKillable>();

        if(tempKillable != null)
        {
            tempKillable.TakeDamage(damage);
        }

        tempKillable = null;

        gameObject.SetActive(false);
    }
}
