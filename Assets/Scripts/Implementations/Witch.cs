using System;
using UnityEngine;

public class Witch : WitchState
{
    private Vector3 offset = new Vector3(0, 0.15f, 0);
    private int potionsCounter = 0;
    
    public override void Attack(Vector3 mousePosition)
    {
        Vector3 projectilePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        projectilePosition.z = 0;

        GameObject projectile = UnityEngine.Object.Instantiate(GameManager.Instance.playerAttack.projectilePrefab, projectilePosition, new Quaternion());
        projectile.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().StartPosition = GameManager.Instance.player.transform.position + offset;
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
        GameManager.Instance.playerAnimator.runtimeAnimatorController = GameManager.Instance.catAnimator;
    }
}