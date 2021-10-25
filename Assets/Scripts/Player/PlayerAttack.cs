using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    [SerializeField] private float attackRadius;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private float rechargeTime;

    private float previousAttack;

    private void Update()
    {
        if (Time.time - previousAttack >= rechargeTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                previousAttack = Time.time;
            }
        }
    }

    private void Attack()
    {
        GameManager.Instance.playerInteraction.Attack();
    }
}
