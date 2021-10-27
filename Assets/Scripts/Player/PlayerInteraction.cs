using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public WitchState state;

    private void Start()
    {
        state = new Witch();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state.ChangeState();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            PickUp();
        }
    }

    public void Attack() => state.Attack();
    public void PickUp() => state.PickUp(transform.position, .5f, 1 << LayerMask.NameToLayer("BaseItems"));
    public void Transform() => state.Transform();
}
