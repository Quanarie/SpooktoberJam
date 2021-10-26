using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public void Heal(float toHeal)
    {
        if (toHeal > 0) currentHp += toHeal;

        if (currentHp > maxHp) currentHp = maxHp;
    }

    protected override void Death()
    {
        SceneManager.LoadScene(0);
    }
}
