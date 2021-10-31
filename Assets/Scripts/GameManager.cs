using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;

    [HideInInspector] public PlayerInteraction playerInteraction;
    [HideInInspector] public PlayerAttack playerAttack;
    [HideInInspector] public PlayerHealth playerHealth;
    [HideInInspector] public HealthBar playerHealthBar;
    [HideInInspector] public Animator playerAnimator;
    [HideInInspector] public RuntimeAnimatorController witchAnimator;
    [HideInInspector] public RuntimeAnimatorController catAnimator;

    public AudioClip energyDrain;
    public AudioClip pickUp;
    public AudioClip TransformToCat;
    public AudioClip TransformToWitch;
    public AudioClip lightningAttack;
    public AudioClip damageEnemy;
    public AudioClip fireball;

    public AudioSource audioSource;

    public HomeEnter homeEnter;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        playerInteraction = player.GetComponent<PlayerInteraction>();
        playerAttack = player.GetComponent<PlayerAttack>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAnimator = player.GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
    }
}
