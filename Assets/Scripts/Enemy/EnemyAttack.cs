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
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (animator.GetBool("isDead"))
            return;

        if (collision.TryGetComponent(out PlayerHealth _))
        {
            collision.GetComponent<Rigidbody2D>().WakeUp();
            if (Time.time - previousAttack >= rechargeTime)
            {
                if (Vector3.Distance(transform.position, GameManager.Instance.player.transform.position) <= attackDistance)
                {
                    Attack();
                    previousAttack = Time.time;
                }
            }

        }
    }

    private void Attack()
    {
        GameManager.Instance.playerHealth.ReceiveDamage(damageAmount, GameManager.Instance.player.transform.position - transform.position, pushForce, GameManager.Instance.playerHealthBar);
        
        animator.SetTrigger("attack");
    }
}
