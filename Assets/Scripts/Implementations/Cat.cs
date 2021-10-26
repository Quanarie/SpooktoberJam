using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : WitchState
{
    private const float decreaseOfHealthCoefficient = 0.15f;

    public void Attack()
    {
        EnemyHealth enemy = FindClosestEnemyInAttackRange();
        if (enemy == null)
            return;

        enemy.ReceiveDamage(GameManager.Instance.playerAttack.damageAmount,
                            enemy.transform.position - GameManager.Instance.player.transform.position,
                            GameManager.Instance.playerAttack.pushForce);

        GameManager.Instance.playerHealth.ReceiveDamage(GameManager.Instance.playerHealth.GetMaxHp() * decreaseOfHealthCoefficient, Vector3.zero, 0f);
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

    private EnemyHealth FindClosestEnemyInAttackRange()
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
        float attackRadius = GameManager.Instance.playerAttack.attackRadius;

        if (Vector3.Distance(playerPos, enemyPos) > attackRadius)
            return null;

        return enemies[closestEnemy];
    }
}
