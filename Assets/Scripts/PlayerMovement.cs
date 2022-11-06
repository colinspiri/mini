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
    public Vector3 movementDirection;
    public Vector3 aimDirection;

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
        movementDirection = new Vector3(horizontal, vertical, 0);
        movementDirection.Normalize();
        
        Vector3 tempMousePos = Input.mousePosition;
        tempMousePos.z = Camera.main.nearClipPlane;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(tempMousePos);
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        aimDirection = mousePosition - transform.position;
        aimDirection.Normalize();
    }

    private void FixedUpdate() {
        rb.velocity = speed * movementDirection;
    }
}
