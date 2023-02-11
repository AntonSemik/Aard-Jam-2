using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speedBase;
    [SerializeField] float stoppingDistance;

    Vector3 direction;
    Rigidbody RB;
    Transform player;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        player = PlayerTransform.instance.transform;
    }

    private void Update()
    {
        if (player != null)
        {
            Move();
        }
    }

    private void Move()
    {
        direction = player.position - transform.position;

        if (direction.sqrMagnitude > Mathf.Pow(stoppingDistance, 2))
        {
            RB.velocity = (player.position - transform.position).normalized * speedBase;
        } else
        {
            RB.velocity = Vector3.zero;
        }
    }
}
