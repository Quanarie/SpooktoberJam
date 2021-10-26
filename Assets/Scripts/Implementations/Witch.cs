using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : WitchState
{
    int potionsCounter = 0;

    public void Attack() 
    {
        EnemyHealth enemy = FindClosestEnemyInAttackRange(GameManager.Instance.playerAttack.attackRadiusBlast);
        if (enemy == null)
            return;

        enemy.ReceiveDamage(GameManager.Instance.playerAttack.damageAmountBlast,
                            enemy.transform.position - GameManager.Instance.player.transform.position,
                            GameManager.Instance.playerAttack.pushForce);
    }

    public void PickUp(Vector3 center, float radius, LayerMask layerMask)
    {
        if (layerMask.value == -1)
            Debug.Log("layermask doesn't exist");
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(center, radius); // I don't understand how layer mask work, but it doesn't work as a third param
        foreach (var collider in colliders) { 
            if (collider.gameObject.layer == LayerMask.NameToLayer("Potion"))
            {
                try
                {
                    collider.GetComponent<BaseItem>().DestroySelf();
                    potionsCounter++;
                }
                catch (Exception e)
                {
                    Debug.LogError($"Unable to destroy {collider.gameObject.name}, error: {e}");
                }
                Debug.Log(potionsCounter);
                return; // I use return here because we want to pick up only the first potion
            }
        }
        
    }

    public void Transform()
    {
        throw new System.NotImplementedException();
    }

    public void ChangeState()
    {
        GameManager.Instance.playerInteraction.state = new Cat();
        GameManager.Instance.player.GetComponent<SpriteRenderer>().color = Color.black;
    }
}
