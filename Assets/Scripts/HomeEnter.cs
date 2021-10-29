using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeEnter : MonoBehaviour
{
    [SerializeField] private int amountOfPotionsToEndGame;
    [SerializeField] private GameObject endCanvas;
    [SerializeField] private float timeForEnding;
    private PlayerInteraction playerInteraction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out playerInteraction))
        {
            if (playerInteraction.potionsCounter >= amountOfPotionsToEndGame)
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
