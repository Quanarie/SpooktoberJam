using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WitchState
{
    public abstract void Attack();
    public abstract void PickUp();
    public abstract void Transform();
    public abstract void ChangeState();

    protected EnemyHealth FindClosestEnemyInAttackRange(float range)
    {
        EnemyHealth[] enemies = Object.FindObjectsOfType<EnemyHealth>();

        if (enemies.Length == 0)
            return null;

        int closestEnemy = 0;

        for (int i = 1; i < enemies.Length; i++)
        {
            if (Vector3.Distance(GameManager.Instance.player.transform.position, enemies[i].transform.position) <
                Vector3.Distance(GameManager.Instance.player.transform.position, enemies[closestEnemy].transform.position))
            {
                closestEnemy = i;
            }
        }

        Vector3 playerPos = GameManager.Instance.player.transform.position;
        Vector3 enemyPos = enemies[closestEnemy].gameObject.transform.position;
        float attackRadius = range;

        if (Vector3.Distance(playerPos, enemyPos) > attackRadius)
            return null;

        return enemies[closestEnemy];
    }
}