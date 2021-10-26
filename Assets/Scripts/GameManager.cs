using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;
    public PlayerInteraction playerInteraction;
    public PlayerAttack playerAttack;
    public PlayerHealth playerHealth;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        playerInteraction = player.GetComponent<PlayerInteraction>();
        playerAttack = player.GetComponent<PlayerAttack>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }
}
