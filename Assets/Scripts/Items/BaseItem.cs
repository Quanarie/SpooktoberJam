using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseItem : MonoBehaviour
{
    [SerializeField] private new string name;
    [SerializeField] private Text newItemText;

    private const float timeToReadText = 2f;

    public virtual void DestroySelf()
    {
        /*if (name == "Flower")
        {
            GameManager.Instance.homeEnter.isFlowerPicked = true;
        }
        else if(name == "Spell")
        {
            GameManager.Instance.homeEnter.isSpellPicked = true;
        }
        else if (name == "Eye")
        {
            GameManager.Instance.homeEnter.frogEyes++;
        }
        else if (name == "Tongue")
        {
            GameManager.Instance.homeEnter.tongues++;
        }
        else if (name == "Hair")
        {
            GameManager.Instance.homeEnter.hair++;
        }
        else if (name == "Heart")
        {
            GameManager.Instance.homeEnter.hearts++;
        }
        else if (name == "Soul")
        {
            GameManager.Instance.homeEnter.souls++;
        }*/

        GameManager.Instance.homeEnter.IncrementIngredient(name);

        newItemText.text = "NEW ITEM: " + GetComponent<BaseItem>().name;
        StartCoroutine(ClearText());

        Destroy(gameObject);
    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(timeToReadText);

        newItemText.text = "";
    }
}
