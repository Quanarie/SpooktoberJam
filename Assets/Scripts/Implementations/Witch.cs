using System;
using UnityEngine;

public class Witch : WitchState
{
    int potionsCounter = 0;
    
    public override void Attack()
    {
        EnemyHealth enemy = FindClosestEnemyInAttackRange(GameManager.Instance.playerAttack.attackRadiusBlast);
        if (enemy == null)
            return;

        enemy.ReceiveDamage(GameManager.Instance.playerAttack.damageAmountBlast,
                            enemy.transform.position - GameManager.Instance.player.transform.position,
                            GameManager.Instance.playerAttack.pushForce);
    }

    public override void PickUp(Vector3 player, float radius, LayerMask layerMask)
    {
        if (layerMask.value == -1)
            Debug.LogError("layermask doesn't exist");

        Collider2D[] items = Physics2D.OverlapCircleAll(player, radius); // I don't understand how layer mask work, but it doesn't work as a third param
        BaseItem savedItem = items[0].GetComponent<BaseItem>();
        float minDistance = float.MaxValue;
        foreach (var item in items)
        {
            float distance = Vector3.Distance(player, item.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                savedItem = item.GetComponent<BaseItem>();
            }
        }
        // savedItem is the searched object
        savedItem.DestroySelf();
        potionsCounter++;
        return;
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
