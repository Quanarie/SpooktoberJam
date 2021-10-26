using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : WitchState
{
    public override void Attack()
    {
        EnemyHealth enemy = FindClosestEnemyInAttackRange(GameManager.Instance.playerAttack.attackRadiusBlast);
        if (enemy == null)
            return;

        enemy.ReceiveDamage(GameManager.Instance.playerAttack.damageAmountBlast,
                            enemy.transform.position - GameManager.Instance.player.transform.position,
                            GameManager.Instance.playerAttack.pushForce);
    }

    public override void PickUp()
    {
        throw new System.NotImplementedException();
    }

    public override void Transform()
    {
        throw new System.NotImplementedException();
    }

    public override void ChangeState()
    {
        GameManager.Instance.playerInteraction.state = new Cat();
        GameManager.Instance.player.GetComponent<SpriteRenderer>().color = Color.black;
    }
}
