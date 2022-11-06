using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameObject objectToFollow;
    private float followSpeed = 2f;

    private Vector3 offset;

    static CameraMovement INSTANCE;

    private void Awake()
    {
        if(INSTANCE != null)
        {
            Destroy(gameObject);
        }
        INSTANCE = this;
    }

    // Start is called before the first frame update
    void Start() {
        offset = transform.position - objectToFollow.transform.position;
    }

    void Update() {
        if (objectToFollow) {
            Vector3 newPos = Vector3.Lerp(transform.position, objectToFollow.transform.position + offset, followSpeed * Time.deltaTime);
            transform.position = newPos;
        }
    }
}