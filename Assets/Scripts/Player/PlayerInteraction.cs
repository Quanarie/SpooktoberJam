using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public WitchState state;

    //[SerializeField] private Text pressE;
    [SerializeField]
    private Image pressE;

    public int potionsCounter;

    GameObject popup;

    private void Start()
    {
        state = new Witch();
        GameManager.Instance.playerAnimator.runtimeAnimatorController = GameManager.Instance.witchAnimator;
        popup = transform.Find("Popup").gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state.ChangeState();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }

    public void Attack(Vector3 mousePosition) => state.Attack(mousePosition);
    public void PickUp() => state.PickUp(transform.position, .5f, 1 << LayerMask.NameToLayer("BaseItems"));

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BaseItem item))
        {
            //pressE.text = "press E to interact";
            popup.SetActive(true);
            popup.transform.Find(item.name).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BaseItem item))
        {
            //pressE.text = "";
            popup.SetActive(false);
            popup.transform.Find(item.name).gameObject.SetActive(false);
        }
    }
}
