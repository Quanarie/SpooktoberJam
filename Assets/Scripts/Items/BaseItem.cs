using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    private string _name;
    private int _id;

    public virtual void DestroySelf() => Destroy(gameObject);
}
