using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAbility : MonoBehaviour
{
    [SerializeField] protected float damageAmount;
    [SerializeField] protected float pushForce;
    [SerializeField] protected float lifetimeOfBlast = 0.3f;
    protected EnemyHealth enemyHealthComponent;

    private void Start()
    {
        Destroy(gameObject, lifetimeOfBlast);
    }
}
