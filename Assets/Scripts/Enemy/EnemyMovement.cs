using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Mover
{
    [SerializeField] private float chasingDistance;
    
    private Animator _animator;
    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(GameManager.Instance.player.transform.position, transform.position) < GetComponent<EnemyAttack>().attackDistance)
        {
            // Enemy starts attacking
            UpdateMotor(Vector3.zero);
            _animator.SetBool("isRunning", false);
            return;
        }

        if (Vector3.Distance(GameManager.Instance.player.transform.position, transform.position) < chasingDistance)
        {
            // Enemy starts chasing enemy
            UpdateMotor((GameManager.Instance.player.transform.position - transform.position).normalized);
            _animator.SetBool("isRunning", true);
        }
        else if (Vector3.Distance(startingPosition, transform.position) < 0.01f)
        {
            UpdateMotor((startingPosition - transform.position).normalized);
        }
        else
        {
            // Player is out of enemy's chasing range and enemy is idle
            _animator.SetBool("isRunning", false);
        }
    }
}
