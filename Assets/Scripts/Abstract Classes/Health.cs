using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float maxHp;

    protected float currentHp;

    private Animator animator;

    private void Start()
    {
        currentHp = maxHp;
        animator = GetComponent<Animator>();
    }

    public void ReceiveDamage(float damage, Vector3 pushDirection, float pushForce)
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

    protected virtual void Death() { }
}
