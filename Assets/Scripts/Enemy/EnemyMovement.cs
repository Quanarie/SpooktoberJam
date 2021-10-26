using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Mover
{
    [SerializeField] private float chasingDistance;

    private Vector3 startingPosition;
    private bool stopped = false;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        if (!stopped)
        {
            if (Vector3.Distance(GameManager.Instance.player.transform.position, transform.position) < chasingDistance)
            {
                UpdateMotor((GameManager.Instance.player.transform.position - transform.position).normalized);
            }
            else if (Vector3.Distance(startingPosition, transform.position) < 0.01f)
            {
                UpdateMotor((startingPosition - transform.position).normalized);
            }
        }   
    }

    public void Stopped(bool s)
    {
        stopped = s;
    }
}
