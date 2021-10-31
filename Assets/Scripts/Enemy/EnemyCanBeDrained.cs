using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCanBeDrained : MonoBehaviour
{
    [SerializeField] private GameObject pickupObject;

    public float healthToHeal;

    private float clickTime = 1f;
    private float currentClickTime;


    private void OnTriggerStay2D(Collider2D collision)
    {
        GameManager.Instance.player.GetComponent<Rigidbody2D>().WakeUp();
        if (collision.TryGetComponent(out PlayerHealth _) && GameManager.Instance.playerInteraction.state.GetType() == typeof(Witch))
        {
            if (Input.GetKey(KeyCode.Mouse1) && GetComponent<EnemyHealth>().GetHp() <= 0)
            {
                currentClickTime += Time.deltaTime;

                GameManager.Instance.playerAnimator.SetBool("isDraining", true);

                GameManager.Instance.audioSource.clip = GameManager.Instance.energyDrain;
                if (!GameManager.Instance.audioSource.isPlaying)
                {
                    GameManager.Instance.audioSource.Play();
                }
            }
            else
            {
                currentClickTime = 0f;

                GameManager.Instance.playerAnimator.SetBool("isDraining", false);
            }
            if (currentClickTime >= clickTime)
            {
                GameManager.Instance.playerAnimator.SetBool("isDraining", false);

                GameManager.Instance.playerHealth.Heal(healthToHeal);
                Destroy(gameObject);

                if (pickupObject == null)
                    return;

                

                pickupObject.GetComponent<BaseItem>().DestroySelf();
            }
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth _))
        {
            GameManager.Instance.playerAnimator.SetBool("isDraining", false);
        }
    }
}
