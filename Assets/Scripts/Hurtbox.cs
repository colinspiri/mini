using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour {
    public GiantHealth health;
    public float damage;
    public float DamageEffectDuration;
    public AnimationCurve DamageEffectCurve;

    SpriteRenderer Renderer;

    private void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
    }

    public void ApplyDamage()
    {
        StopAllCoroutines();
        StartCoroutine(CR_PlayDamageEffect());
        StartCoroutine(CameraShake.Instance.Shake(0.05f));
        health.TakeDamage(damage);
    }

    IEnumerator CR_PlayDamageEffect()
    {

        float startTime = Time.unscaledTime;
        float endTime = Time.unscaledTime + DamageEffectDuration;

        while (Time.unscaledTime < endTime)
        {
            float elapsedTime = Time.unscaledTime - startTime;

 
            float eval = DamageEffectCurve.Evaluate(elapsedTime / DamageEffectDuration);
            Renderer.color = Color.Lerp(Color.white, Color.red, eval);
            yield return null;
        }
        Renderer.color = Color.white;
    }

}
