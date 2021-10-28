using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected override void Death()
    {
        //GetComponent<SpriteRenderer>().color = Color.grey;
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<EnemyHealth>().enabled = false;
        GetComponent<Animator>().SetTrigger("dying");


        gameObject.AddComponent(typeof(EnemyCanBeDrained));
        GetComponent<EnemyCanBeDrained>().healthToHeal = GetComponent<EnemyHealth>().GetMaxHp() * 0.1f;
    }
}
