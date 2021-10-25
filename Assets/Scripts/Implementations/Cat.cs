using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : WitchState
{
    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void PickUp() { }

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
