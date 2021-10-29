using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeEnter : MonoBehaviour
{
    [SerializeField] private int amountOfPotionsToEndGame;
    private PlayerInteraction playerInteraction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out playerInteraction))
        {
            if (playerInteraction.potionsCounter >= amountOfPotionsToEndGame)
            {
                //smth in ui
            }
        }
    }
}
