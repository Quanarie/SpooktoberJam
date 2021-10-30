using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    [SerializeField] private AnimationClip deathAnimation;
    [SerializeField] protected Slider healthSlider;

    protected override void Start()
    {
        base.Start();
        healthSlider.value = currentHp;
    }

    public override void ReceiveDamage(float damage, Vector3 pushDirection, float pushForce, HealthBar healthBar = null)
    {
        base.ReceiveDamage(damage, pushDirection, pushForce, healthBar);

        healthSlider.value = currentHp;
    }

    public void Heal(float toHeal)
    {
        if (toHeal > 0) currentHp += toHeal;

        if (currentHp > maxHp) currentHp = maxHp;

        healthSlider.value = currentHp;
    }

    protected override void Death()
    {
        GameManager.Instance.playerAnimator.SetBool("isDead", true);
        StartCoroutine(WaitForDeathAnimationToEnd());
    }

    IEnumerator WaitForDeathAnimationToEnd()
    {
        yield return new WaitForSeconds(deathAnimation.length);

        SceneManager.LoadScene(0);
    }
}
