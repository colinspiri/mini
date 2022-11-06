using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour {
    public float currentSize;
    public float minSize;
    public float maxSize;
    public float growSpeed;
    public float shrinkSpeed;
    public KeyCode shrinkKey;

    public Camera camera;
    public float minCameraSize;
    public float maxCameraSize;

    // Start is called before the first frame update
    void Start() {
        currentSize = transform.localScale.x;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0)) {
            if(currentSize > minSize) currentSize -= shrinkSpeed * Time.deltaTime;
        }
        else {
            if(currentSize < maxSize) currentSize += growSpeed * Time.deltaTime;
        }

        UpdateSize();
    }

    private void UpdateSize() {
        transform.localScale = new Vector3(currentSize, currentSize, currentSize);
        camera.orthographicSize = Mathf.Lerp(minCameraSize, maxCameraSize, (currentSize - minSize) / maxSize);
    }
}
