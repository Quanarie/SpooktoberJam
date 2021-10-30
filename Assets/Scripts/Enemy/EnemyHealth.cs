using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    private const float coefficientToRegen = 0.1f;

    protected override void Death()
    {
        //GetComponent<SpriteRenderer>().color = Color.grey;
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<EnemyHealth>().enabled = false;
        GetComponent<Animator>().SetBool("isDead", true);
        GetComponent<Animator>().SetTrigger("death");


        gameObject.AddComponent(typeof(EnemyCanBeDrained));
        GetComponent<EnemyCanBeDrained>().healthToHeal = GameManager.Instance.playerHealth.GetMaxHp() * coefficientToRegen;
    }
}
