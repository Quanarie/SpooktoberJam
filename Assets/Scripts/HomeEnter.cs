using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeEnter : MonoBehaviour
{
    [SerializeField] private int amountOfPotionsToEndGame;
    [SerializeField] private GameObject endCanvas;
    [SerializeField] private float timeForEnding;

    public bool isFlowerPicked;
    public bool isSpellPicked;
    public int frogEyes;
    public int maxFrogEyes;
    public int tongues;
    public int maxTongues;
    public int hair;
    public int maxHair;
    public int hearts;
    public int maxHearts;
    public int souls;
    public int maxSouls;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerInteraction _))
        {
            if (HasAllIngredients())
            {
                StartCoroutine(endGame());
            }
        }
    }

    private bool HasAllIngredients()
    {
        return (isFlowerPicked && isSpellPicked &&
                frogEyes >= maxFrogEyes && tongues >= maxTongues && hair >= maxHair && hearts >= maxHearts && souls >= maxSouls);
    }

    IEnumerator endGame()
    {
        //Should play a sound effect
        yield return new WaitForSeconds(timeForEnding);
        SceneManager.LoadScene(2);
    }

    public void IncrementIngredient(string ingredient)
    {
        if (ingredient == "Flower")
        {
            isFlowerPicked = true;
        }
        else if (ingredient == "Spell")
        {
            isSpellPicked = true;
        }
        else if (ingredient == "Eye")
        {
            ++frogEyes;
        }
        else if (ingredient == "Tongue")
        {
            ++tongues;
        }
        else if (ingredient == "Hair")
        {
            ++hair;
        }
        else if (ingredient == "Heart")
        {
            ++hearts;
        }
        else if (ingredient == "Soul")
        {
            ++souls;
        }
    }
}
