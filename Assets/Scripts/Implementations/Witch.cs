using System;
using UnityEngine;

public class Witch : WitchState
{
    private const float lifetimeOfBlast = 0.5f;
    private int potionsCounter = 0;
    
    public override void Attack(Vector3 mousePosition, GameObject projectilePrefab)
    {
        Vector3 projectilePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        projectilePosition.z = 0;

        GameObject projectile = UnityEngine.Object.Instantiate(projectilePrefab, projectilePosition, new Quaternion());
        UnityEngine.Object.Destroy(projectile, lifetimeOfBlast);
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