using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : WitchState
{
    public void Attack() { }

    public void PickUp()
    {
        throw new System.NotImplementedException();
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
