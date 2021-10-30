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

        Vector3 mDir = fireballDirection;
        Vector3 fDir = Vector3.right;

        float angleBetweenMouseAndFireballDirections = Mathf.Acos((mDir.x * fDir.x + mDir.y * fDir.y + mDir.z * fDir.z) / (mDir.magnitude * fDir.magnitude)) * 180 / Mathf.PI;
        if (Camera.main.ScreenToWorldPoint(mousePosition).y < GameManager.Instance.player.transform.position.y) angleBetweenMouseAndFireballDirections *= -1;

        GameObject fireball = UnityEngine.Object.Instantiate(GameManager.Instance.playerAttack.fireballPrefab, GameManager.Instance.player.transform.position, new Quaternion());
        fireball.GetComponent<CatFireball>().direction = fireballDirection;
        fireball.transform.rotation = Quaternion.Euler(0f, 0f, angleBetweenMouseAndFireballDirections);

        GameManager.Instance.playerHealth.ReceiveDamage(GameManager.Instance.playerHealth.GetMaxHp() * decreaseOfHealthCoefficient, Vector3.zero, 0f);
    }

    public override void PickUp(Vector3 center, float radius, LayerMask layerMask) { }

    public override void ChangeState()
    {
        GameManager.Instance.playerInteraction.state = new Witch();
        GameManager.Instance.playerAnimator.runtimeAnimatorController = GameManager.Instance.witchAnimator;

        GameManager.Instance.audioSource.clip = GameManager.Instance.TransformToWitch;
        GameManager.Instance.audioSource.Play();
    }
}
