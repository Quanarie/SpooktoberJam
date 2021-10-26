using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Health : MonoBehaviour
{
    [SerializeField] private int maxHp;

    private float currentHp;
    private Rigidbody2D rb;

    private void Start()
    {
        currentHp = maxHp;
        rb = GetComponent<Rigidbody2D>();
    }

    public void ReceiveDamage(float damage)
    {
        Debug.Log("Taking the following amount of damage: " + damage);
        currentHp -= damage;
        Debug.Log("Current HP: " + currentHp);
        if (currentHp <= 0)
        {
            currentHp = 0;
            Death();
        }
    }

    public void ReceiveDamage(float damage, Vector2 pushDirection, float pushForce = 1)
    {
        pushDirection.Normalize();
        pushDirection *= pushForce;
        rb.AddForce(pushDirection, ForceMode2D.Impulse);

        ReceiveDamage(damage);
    }

    protected virtual void Death() { }
}
