using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // components
    public static PlayerMovement Instance;
    private Rigidbody2D rb;
    
    // constants
    public float speed;

    // state
    public Vector3 direction;

    private void Awake() {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        direction = new Vector3(horizontal, vertical, 0);
        direction.Normalize();
    }

    private void FixedUpdate() {
        rb.velocity = speed * direction;
    }
    

    /*private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.TryGetComponent(out Bullet bullet)) {
            if (!bullet.belongsToPlayer) {
                // die
                Destroy(gameObject);
            }
        }
    }*/
}
