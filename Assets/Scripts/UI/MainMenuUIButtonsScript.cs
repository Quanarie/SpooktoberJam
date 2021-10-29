using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIButtonsScript : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Closed application");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
