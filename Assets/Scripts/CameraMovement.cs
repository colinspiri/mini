using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameObject objectToFollow;
    private float followSpeed = 2f;
    public AnimationCurve ScreenShakeCurve;
    public float shakeSpeed = 5.0f;

    private Vector3 offset;

    static CameraMovement INSTANCE;

    Vector3 shakeVec;

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
            transform.position = newPos + shakeVec;
        }
    }

    public static void ScreenShake(float magnitude, float duration)
    {
        INSTANCE.StopAllCoroutines();
        INSTANCE.StartCoroutine(INSTANCE.CR_ScreenShake(magnitude, duration));
    }

    IEnumerator CR_ScreenShake(float magnitude, float duration)
    {
        float startTime = Time.time;
        float endTime = Time.time + duration;

        while (Time.time < endTime)
        {
            float elapsedTime = Time.time - startTime;
            float eval = ScreenShakeCurve.Evaluate(elapsedTime / duration);

            shakeVec.x = Mathf.Sin(Time.time * shakeSpeed) * eval * magnitude;
            shakeVec.y = (Mathf.PerlinNoise(0f, Time.time * shakeSpeed)-.5f) * eval * magnitude;

            yield return null;
        }
        shakeVec = Vector3.zero;
    }
}