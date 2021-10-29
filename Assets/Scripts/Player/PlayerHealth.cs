using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    [SerializeField] private AnimationClip deathAnimation;

    public void Heal(float toHeal)
    {
        if (toHeal > 0) currentHp += toHeal;

        if (currentHp > maxHp) currentHp = maxHp;
    }

    protected override void Death()
    {
        GameManager.Instance.playerAnimator.SetBool("isDead", true);
        //StartCoroutine(WaitForDeathAnimationToEnd());
    }

    IEnumerator WaitForDeathAnimationToEnd()
    {
        yield return new WaitForSeconds(deathAnimation.length);

        SceneManager.LoadScene(0);
    }
}
