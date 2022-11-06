using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public float currentHealth;

    public void ApplyDamage() {
        currentHealth -= 1;
        if (currentHealth <= 0) {
            // game over
            Debug.Log("game over");
        }
    }
}
