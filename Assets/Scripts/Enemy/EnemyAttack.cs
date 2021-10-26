using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackForce;
    [SerializeField] private float rechargeTime;

    private float previousAttack;

    private PlayerHealth playerHealth;
    private CircleCollider2D attackRadius;
    private EnemyMovement movement;

    private void Start()
    {
        playerHealth = GameManager.Instance.player.GetComponent<PlayerHealth>();
        attackRadius = GetComponent<CircleCollider2D>();
        if (!attackRadius.isTrigger)
            attackRadius.isTrigger = true;
        attackRadius.radius = attackDistance;
        movement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (Time.time - previousAttack >= rechargeTime)
        {
            if (Vector3.Distance(transform.position, GameManager.Instance.player.transform.position) <= attackDistance)
            {
                Attack();
                previousAttack = Time.time;
            }
        }
    }

    private void Attack()
    {
        playerHealth.ReceiveDamage(damageAmount);
    }

    private void Attack(Transform target)
    {
        playerHealth.ReceiveDamage(damageAmount, (target.position - transform.position), attackForce);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            movement.Stopped(true);
            Attack(other.transform);
        }        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            movement.Stopped(false);
        }
    }
}
