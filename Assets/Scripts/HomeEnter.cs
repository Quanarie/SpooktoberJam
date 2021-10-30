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
    public int frogEyes;    //4
    public int tongues;    //2
    public int hair;    //4
    public int hearts;    //1
    public int souls;   //3

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerInteraction _))
        {
            if (isFlowerPicked && isSpellPicked &&
                frogEyes >= 4 && tongues >= 2 && hair >= 4 && hearts >= 1 && souls >= 3)
            {
                endCanvas.SetActive(true);
                StartCoroutine(endGame());
            }
        }
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(timeForEnding);
        SceneManager.LoadScene(0);
    }
}
