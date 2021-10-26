using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanBeDrained : MonoBehaviour
{
    public float healthToHeal;

    private float clickTime = 1f;
    private float currentClickTime;

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameManager.Instance.player.GetComponent<Rigidbody2D>().WakeUp();
        if (collision.TryGetComponent(out PlayerHealth _) && GameManager.Instance.playerInteraction.state.GetType() == typeof(Witch))
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                currentClickTime += Time.deltaTime;
                print(currentClickTime);
            }
            else
            {
                currentClickTime = 0f;
            }
            if (currentClickTime >= clickTime)
            {
                GameManager.Instance.playerHealth.Heal(healthToHeal);
                Destroy(gameObject);
            }
        }
    }
}
