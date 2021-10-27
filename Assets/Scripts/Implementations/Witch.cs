using System;
using UnityEngine;

public class Witch : WitchState
{
    private int potionsCounter = 0;
    
    public override void Attack()
    {
        EnemyHealth enemy = FindClosestEnemyInAttackRange(GameManager.Instance.playerAttack.attackRadiusBlast);

        float playerPositionX = GameManager.Instance.player.transform.position.x;
        float playerLocalScaleX = GameManager.Instance.player.transform.localScale.x;

        if (enemy == null || enemy.transform.position.x * playerLocalScaleX < playerPositionX * playerLocalScaleX)
            return;

        enemy.ReceiveDamage(GameManager.Instance.playerAttack.damageAmountBlast,
                            enemy.transform.position - GameManager.Instance.player.transform.position,
                            GameManager.Instance.playerAttack.pushForce);
    }

    public override void PickUp(Vector3 playerPosition, float radius, LayerMask layerMask)
    {
        Collider2D[] items = Physics2D.OverlapCircleAll(playerPosition, radius, layerMask);

        if (items.Length == 0)
            return;

        int nearestItemIndex = 0;
        for (int i = 1; i < items.Length; i++)
        {
            if (Vector3.Distance(playerPosition, items[i].transform.position) < Vector3.Distance(playerPosition, items[nearestItemIndex].transform.position))
            {
                nearestItemIndex = i;
            }
        }

        items[nearestItemIndex].GetComponent<BaseItem>().DestroySelf();
        potionsCounter++;
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
