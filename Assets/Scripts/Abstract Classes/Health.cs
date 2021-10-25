using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private int maxHp;

    private int currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void ReceiveDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            currentHp = 0;
            Death();
        }
    }

    protected virtual void Death() { }
}
