using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    private Slider _healthBar; 

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
    }

    public void SetValue(float health)
    {
        _healthBar.value = health;
    }

    public void SetMax(float maxHealth)
    {
        _healthBar.maxValue = maxHealth;
    }
}
