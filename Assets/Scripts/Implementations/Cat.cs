using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : WitchState
{
    private const float decreaseOfHealthCoefficient = 0.1f;

    public override void Attack(Vector3 mousePosition)
    {
        Vector3 fireballDirection = Camera.main.ScreenToWorldPoint(mousePosition) - GameManager.Instance.player.transform.position;
        fireballDirection.z = 0;

        GameObject fireball = UnityEngine.Object.Instantiate(GameManager.Instance.playerAttack.fireballPrefab, GameManager.Instance.player.transform.position, new Quaternion());
        fireball.GetComponent<CatFireball>().direction = fireballDirection;

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
