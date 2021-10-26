using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private int maxHp;

    private int currentHp;

    private Color prevcolor;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void ReceiveDamage(int damage, Vector3 pushDirection, float pushForce)
    {
        GetComponent<Mover>().pushDirection = pushDirection.normalized * pushForce;

        currentHp -= damage;
        if (currentHp <= 0)
        {
            currentHp = 0;
            Death();
        }

        prevcolor = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().color = prevcolor;
    }

    protected virtual void Death() { }
}
