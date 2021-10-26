using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : WitchState
{
    private const float decreaseOfHealthCoefficient = 0.15f;

    public void Attack()
    {
        EnemyHealth enemy = FindClosestEnemyInAttackRange(GameManager.Instance.playerAttack.attackRadiusClaw);
        if (enemy == null)
            return;

        enemy.ReceiveDamage(GameManager.Instance.playerAttack.damageAmountClaw,
                            enemy.transform.position - GameManager.Instance.player.transform.position,
                            GameManager.Instance.playerAttack.pushForce);

        GameManager.Instance.playerHealth.ReceiveDamage(GameManager.Instance.playerHealth.GetMaxHp() * decreaseOfHealthCoefficient, Vector3.zero, 0f);
    }

    public void PickUp(Vector3 center, float radius, LayerMask layerMask) { Debug.Log("Pick up called"); }

    public void Transform()
    {
        throw new System.NotImplementedException();
    }

    public void ChangeState()
    {
        GameManager.Instance.playerInteraction.state = new Witch();
        GameManager.Instance.player.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
