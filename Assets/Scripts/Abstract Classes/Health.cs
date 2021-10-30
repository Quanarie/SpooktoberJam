using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float maxHp;
    [SerializeField] protected Slider healthSlider;

    protected float currentHp;

    private Animator animator;

    private void Start()
    {
        currentHp = maxHp;
        animator = GetComponent<Animator>();

        healthSlider.value = currentHp;
    }

    public void ReceiveDamage(float damage, Vector3 pushDirection, float pushForce, HealthBar healthBar = null)
    {
        GetComponent<Mover>().pushDirection = pushDirection.normalized * pushForce;

        currentHp -= damage;

        if (currentHp <= 0)
        {
            currentHp = 0;
            Death();
        }

        healthSlider.value = currentHp;

        if (animator != null)
            animator.SetTrigger("damage");
    }

    public float GetMaxHp() => maxHp;

    protected virtual void Death() { }
}
