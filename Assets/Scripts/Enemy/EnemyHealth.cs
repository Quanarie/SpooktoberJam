using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    private const float coefficientToRegen = 0.1f;
    private const float timeTakingDamage = 1f;
    private SpriteRenderer spriteRenderer;
    private Color color;

    protected override void Start()
    {
        base.Start();

        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
    }

    public override void ReceiveDamage(float damage, Vector3 pushDirection, float pushForce, HealthBar healthBar = null)
    {
        base.ReceiveDamage(damage, pushDirection, pushForce, healthBar);

        spriteRenderer.color = Color.red;

        StartCoroutine(ChangeColorBack());
    }

    IEnumerator ChangeColorBack()
    {
        yield return new WaitForSeconds(timeTakingDamage);
        spriteRenderer.color = color;
    }

    protected override void Death()
    {
        if (GetComponent<Animator>().GetBool("isDead"))
            return;

        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<EnemyHealth>().enabled = false;
        GetComponent<Animator>().SetBool("isDead", true);
        transform.localScale = new Vector3(transform.localScale.x/2, transform.localScale.y, transform.localScale.z);
        transform.eulerAngles = new Vector3(0, 0, 90);


        gameObject.AddComponent(typeof(EnemyCanBeDrained));
        GetComponent<EnemyCanBeDrained>().healthToHeal = GameManager.Instance.playerHealth.GetMaxHp() * coefficientToRegen;
    }
}
