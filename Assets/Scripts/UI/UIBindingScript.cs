using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBindingScript : MonoBehaviour
{
    [SerializeField] private Canvas _inGameMenuCanvas;

    private bool _isActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isActive = _inGameMenuCanvas.isActiveAndEnabled;
            _inGameMenuCanvas.gameObject.SetActive(!_isActive);
            if (!_isActive)
            {
                Time.timeScale = 0;
                GameManager.Instance.playerAttack.enabled = false;
            }
            else
            {
                Time.timeScale = 1;
                GameManager.Instance.playerAttack.enabled = true;
            }
        }
    }
}
