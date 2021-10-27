using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float rechargeTime;
    public GameObject projectilePrefab;
    public GameObject fireballPrefab;

    private Animator animator;

    public Vector3 attackPoint;

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
                GameManager.Instance.playerInteraction.Attack(Input.mousePosition);

                previousAttack = Time.time;

                animator.SetTrigger("attack");
            }
        }
    }
}
