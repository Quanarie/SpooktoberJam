using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    [SerializeField] private float attackRadius;
    [SerializeField] private float rechargeTime;

    private float previousAttack;

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameManager.Instance.player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (Time.time - previousAttack >= rechargeTime)
        {
            if (Vector3.Distance(transform.position, GameManager.Instance.player.transform.position) <= attackRadius)
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
}
