using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float rechargeTime;
    [SerializeField] private GameObject projectilePrefab;

    private Animator animator;

    public float damageAmountClaw;
    public float attackRadiusClaw;
    public Vector3 attackPoint;
    public float pushForce;

    private float previousAttack = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.time - previousAttack >= rechargeTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.playerInteraction.Attack(Input.mousePosition, projectilePrefab);

                previousAttack = Time.time;

                animator.SetTrigger("attack");
            }
        }
    }
}
