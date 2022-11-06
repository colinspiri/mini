using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameObject objectToFollow;
    private float followSpeed = 5f;
    public float lookAheadMultiplier;
    
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
    }

    void Update() {
        if (objectToFollow) {
            Vector3 targetPos = objectToFollow.transform.position +
                                lookAheadMultiplier * PlayerMovement.Instance.transform.localScale.x * PlayerMovement.Instance.aimDirection;
            Vector3 newPos = Vector3.Lerp(transform.position, targetPos, 1);
            transform.position = newPos;
        }
    }
}