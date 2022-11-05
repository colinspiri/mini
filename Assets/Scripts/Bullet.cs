using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    // components
    public Rigidbody2D rb;
    
    // constants
    public float speed;
    public Vector3 direction;
    
    // state
    public bool belongsToPlayer;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        rb.velocity = speed * direction;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (belongsToPlayer == false && col.gameObject.CompareTag("Player")) {
            Destroy(col.gameObject);
        }

        if (belongsToPlayer && col.gameObject.CompareTag("Enemy")) {
            Destroy(col.gameObject);
        }
    }
}
