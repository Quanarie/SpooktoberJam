using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damageAmount;
    [SerializeField] private float rechargeTime;
    [SerializeField] private float pushForce;

    public float attackDistance;

    private float previousAttack;

    private void Update()
    {
        if (Time.time - previousAttack >= rechargeTime)
            if (Vector3.Distance(transform.position, GameManager.Instance.player.transform.position) <= attackDistance)
                previousAttack = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Attack();        
    }

    private void Attack()
    {
        GameManager.Instance.playerHealth.ReceiveDamage(damageAmount, GameManager.Instance.player.transform.position - transform.position, pushForce, GameManager.Instance.playerHealthBar);
    }
}
