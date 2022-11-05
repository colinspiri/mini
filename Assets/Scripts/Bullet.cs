using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    // constants
    public float speed;
    public Vector3 direction;
    
    // state
    public bool belongsToPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InitializeBullet(Vector3 bulletDirection, bool bulletBelongsToPlayer) {
        direction = new Vector3(bulletDirection.x, bulletDirection.y, bulletDirection.z);
        belongsToPlayer = bulletBelongsToPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
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
