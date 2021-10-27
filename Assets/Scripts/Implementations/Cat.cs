using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : WitchState
{
    private const float decreaseOfHealthCoefficient = 0.1f;

    public override void Attack(Vector3 mousePosition, GameObject projectilePrefab)
    {
        EnemyHealth enemy = FindClosestEnemyInAttackRange(GameManager.Instance.playerAttack.attackRadiusClaw);
        if (enemy == null)
            return;

        enemy.ReceiveDamage(GameManager.Instance.playerAttack.damageAmountClaw,
                            enemy.transform.position - GameManager.Instance.player.transform.position,
                            GameManager.Instance.playerAttack.pushForce);

        GameManager.Instance.playerHealth.ReceiveDamage(GameManager.Instance.playerHealth.GetMaxHp() * decreaseOfHealthCoefficient, Vector3.zero, 0f);
    }

    public override void PickUp(Vector3 center, float radius, LayerMask layerMask) { }


    public override void Transform()
    {
        throw new System.NotImplementedException();
    }

    public override void ChangeState()
    {
        GameManager.Instance.playerInteraction.state = new Witch();
        GameManager.Instance.playerAnimator.runtimeAnimatorController = GameManager.Instance.witchAnimator;
    }
}
