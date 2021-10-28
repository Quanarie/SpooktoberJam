using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuButtonsScript : MonoBehaviour
{
    [SerializeField] private Canvas _menuCanvas;

    public void ContinueGame()
    {
        _menuCanvas.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("We left the application");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        // loads the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
