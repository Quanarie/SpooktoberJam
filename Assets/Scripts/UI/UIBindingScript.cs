using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBindingScript : MonoBehaviour
{
    [SerializeField] private Canvas _inGameMenuCanvas;

    private bool _isActive = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isActive = _inGameMenuCanvas.isActiveAndEnabled;
            _inGameMenuCanvas.gameObject.SetActive(!_isActive);
        }
            
    }
}
