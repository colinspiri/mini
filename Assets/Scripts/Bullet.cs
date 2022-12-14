using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Actor {
    // components
    public Rigidbody2D rb;
    
    // constants
    public float speed;
    public Vector3 direction;

    public float lifeTime;
    
    // state
    public bool belongsToPlayer;
    public bool grow;

    float elapsedTime;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        elapsedTime = 0;
    }

    // Update is called once per frame
    void Update() {
        rb.velocity = speed * direction;
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= lifeTime)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (!belongsToPlayer && col.gameObject.CompareTag("Player"))
        {
            if(grow) col.SendMessage("Grow");
            else col.SendMessage("ApplyDamage");
            Die();
        }

        if (belongsToPlayer && col.gameObject.CompareTag("Enemy"))
        {
            col.SendMessage("ApplyDamage");
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
