using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseItem : MonoBehaviour
{
    [SerializeField] private new string name;
    //[SerializeField] private Text newItemText;

    private const float timeToReadText = 2f;

    public virtual void DestroySelf()
    {
        GameManager.Instance.homeEnter.IncrementIngredient(name);

        //newItemText.text = "NEW ITEM: " + GetComponent<BaseItem>().name;
        //StartCoroutine(ClearText());

        Destroy(gameObject);
    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(timeToReadText);

        //newItemText.text = "";
    }
}
