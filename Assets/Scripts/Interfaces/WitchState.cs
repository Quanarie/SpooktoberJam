using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WitchState
{
    public void Attack();
    public void PickUp(Vector3 center, float radius, LayerMask layerMask);
    public void Transform();
    public void ChangeState();
}