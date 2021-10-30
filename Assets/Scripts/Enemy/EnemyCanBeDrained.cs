using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCanBeDrained : MonoBehaviour
{
    [SerializeField] private GameObject pickupObject;
    [SerializeField] private Text newItemText;

    public float healthToHeal;

    private float clickTime = 1f;
    private float currentClickTime;

    private const float timeToReadText = 2f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameManager.Instance.player.GetComponent<Rigidbody2D>().WakeUp();
        if (collision.TryGetComponent(out PlayerHealth _) && GameManager.Instance.playerInteraction.state.GetType() == typeof(Witch))
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                currentClickTime += Time.deltaTime;

                GameManager.Instance.playerAnimator.SetBool("isDraining", true);

                GameManager.Instance.audioSource.clip = GameManager.Instance.energyDrain;
                GameManager.Instance.audioSource.Play();
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

                newItemText.text = "NEW ITEM: " + pickupObject.GetComponent<BaseItem>().name;
                StartCoroutine(ClearText());

                pickupObject.GetComponent<BaseItem>().DestroySelf();
            }
        }
    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(timeToReadText);

        newItemText.text = "";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth _))
        {
            GameManager.Instance.playerAnimator.SetBool("isDraining", false);
        }
    }
}
