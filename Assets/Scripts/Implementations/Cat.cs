using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : WitchState
{
    public void Attack()
    {
        Collider2D enemy = FindClosestEnemy();
        if (enemy == null)
            return;

        enemy.GetComponent<EnemyHealth>().ReceiveDamage(GameManager.Instance.playerAttack.damageAmount);
    }

    public void PickUp() { }

    public void Transform()
    {
        throw new System.NotImplementedException();
    }

    public void ChangeState()
    {
        GameManager.Instance.playerInteraction.state = new Witch();
        GameManager.Instance.player.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private Collider2D FindClosestEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GameManager.Instance.playerAttack.attackPoint,
                                                       GameManager.Instance.playerAttack.attackRadius);

        colliders = DeleteNonEnemyObjects(colliders);

        if (colliders.Length == 0)
            return null;

        int closestEnemy = 0;

        for (int i = 1; i < colliders.Length; i++)
        {
            if (Vector3.Distance(GameManager.Instance.player.transform.position, colliders[i].transform.position) <
                Vector3.Distance(GameManager.Instance.player.transform.position, colliders[closestEnemy].transform.position))
            {
                closestEnemy = i;
            }
        }

        return colliders[closestEnemy];
    }

    private Collider2D[] DeleteNonEnemyObjects(Collider2D[] colliders)
    {
        int amountOfEnemies = 0;
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out EnemyHealth _))
            {
                amountOfEnemies++;
            }
        }

        Collider2D[] enemies = new Collider2D[amountOfEnemies];

        int enemiesIndex = 0;
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out EnemyHealth _))
            {
                enemies[enemiesIndex] = colliders[i];
                enemiesIndex++;
            }
        }

        return enemies;
    }
}
