using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{
    public Slider slider;

    private int maxHealth;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int value)
    {
        slider.value = value;
    }

    private void Start()
    {
        maxHealth = GameManager.instance.maxPlayerHealth;
        SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        SetHealth(GameManager.instance.currentPlayerHealth);
    }
}
