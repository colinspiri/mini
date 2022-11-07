using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour {
    public float maxHealth;
    private float currentHealth;

    private float targetSize;
    private float currentSize;
    public float minSize;
    public float maxSize;
    private float lerpSpeed = 2f;

    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
        UpdateSize();
    }

    private void Update() {
        SetSize(Mathf.Lerp(currentSize, targetSize, lerpSpeed * Time.deltaTime));
    }

    private void SetSize(float size) {
        currentSize = size;
        transform.localScale = new Vector3(currentSize, currentSize, currentSize);
    }

    private void UpdateSize() {
        targetSize = Mathf.Lerp(minSize, maxSize, currentHealth / maxHealth);
    }

    public void ApplyDamage() {
        currentHealth -= 1;
        UpdateSize();
        
        if (currentHealth <= 0) {
            currentHealth = 0;
            // game over
            Debug.Log("game over");
        }
    }

    public void Grow() {
        currentHealth += 1;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        
        UpdateSize();
    }
}
