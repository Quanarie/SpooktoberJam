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
        GameManager.Instance.player.GetComponent<PlayerInteraction>().state = new Witch();
    }
}
