using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float maxHp;

    protected float currentHp;

    private Animator animator;

    protected virtual void Start()
    {
        currentHp = maxHp;
        animator = GetComponent<Animator>();

    }

    public virtual void ReceiveDamage(float damage, Vector3 pushDirection, float pushForce, HealthBar healthBar = null)
    {
        GetComponent<Mover>().pushDirection = pushDirection.normalized * pushForce;

        currentHp -= damage;

        if (currentHp <= 0)
        {
            currentHp = 0;
            Death();
        }

        if (animator != null)
            animator.SetTrigger("damage");
    }

    public float GetMaxHp() => maxHp;

    public float GetHp() => currentHp;

    protected virtual void Death() { }
}
