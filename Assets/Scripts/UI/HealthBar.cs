using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _ownerHealth;
    private Slider _slider;
    

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _ownerHealth.GetMaxHp();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            SetHealthbarValue(100);
        if (Input.GetKeyDown(KeyCode.P))
            AddHealthbarValue(10);
        if (Input.GetKeyDown(KeyCode.L))
            SubstractHealthbarValue(10);

    }

    /// <summary>
    /// Sets the health bar value to value parameter
    /// </summary>
    /// <param name="value">The new healthbar value</param>
    public void SetHealthbarValue(int value)
    {
        _slider.value = value;
    }

    /// <summary>
    /// Adds value to current healthbar value
    /// </summary>
    /// <param name="value">Value to add in healthbar</param>
    public void AddHealthbarValue(float value)
    {
        _slider.value += value;
    }

    /// <summary>
    /// Substracts value from healthbar
    /// </summary>
    /// <param name="value">Value to substract</param>
    public void SubstractHealthbarValue(float value)
    {
        _slider.value -= value;
    }

}
