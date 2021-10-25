using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WitchState
{
    public void Attack();
    public void PickUp();
    public void Transform();
    public void ChangeState();
}