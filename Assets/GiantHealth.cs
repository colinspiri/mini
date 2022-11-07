using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiantHealth : MonoBehaviour {
    public float maxHealth;
    private float currentHealth;
    public Slider slider;

    private void Start() {
        currentHealth = maxHealth;
        slider.value = 1;
    }

    public void TakeDamage(float damage = 1) {
        currentHealth -= damage;
        slider.value = currentHealth / maxHealth;
        if (currentHealth <= 0) {
            Debug.Log("WIN!");
        }
    }
}
