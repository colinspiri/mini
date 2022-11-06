using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GiantShoot : MonoBehaviour {
    public GameObject bulletProviderObject;

    [Header("Shoot At Player")]
    public Transform gunNozzle;
    public float shootAtPlayerDelay;
    [Header("Shoot Wave")] 
    public float shootWaveDelay;
    public float shootWaveMinAngle;
    public float shootWaveMaxAngle;
    public float shootWaveIncrease;

    IProvider<Bullet> bulletProvider;
    
    // state
    private float shootAtPlayerCooldown;
    private float shootWaveCooldown;
    private float shootWaveAngle;

    // Start is called before the first frame update
    void Start()
    {
        bulletProvider = bulletProviderObject.GetComponent<IProvider<Bullet>>();
    }

    // Update is called once per frame
    void Update() {
        if (shootAtPlayerCooldown > 0) {
            shootAtPlayerCooldown -= Time.deltaTime;
        }
        else {
            ShootAtPlayer();
            shootAtPlayerCooldown = shootAtPlayerDelay;
        }

        if (shootWaveCooldown > 0) {
            shootWaveCooldown -= Time.deltaTime;
        }
        else {
            ShootWave();
            shootWaveCooldown = shootWaveDelay;
        }

        
    }

    private void ShootAtPlayer() {
        Vector3 toPlayer = PlayerMovement.Instance.transform.position - transform.position;
        toPlayer.Normalize();
        ShootBullet(gunNozzle.position, toPlayer);
    }

    private void ShootWave() {
        // make direction vector from angle
        Vector2 dir = (Vector2)(Quaternion.Euler(0,0,shootWaveAngle) * Vector2.right);
        dir.Normalize();
        ShootBullet(gunNozzle.position, dir);

        // increase angle
        shootWaveAngle += shootWaveIncrease;
        if (shootWaveAngle > shootWaveMaxAngle) shootWaveAngle = shootWaveMinAngle;
    }

    private void ShootBullet(Vector3 spawnPosition, Vector3 direction) {
        Bullet bullet = bulletProvider.Get();
        bullet.transform.position = spawnPosition;
        bullet.transform.rotation = Quaternion.identity;
        bullet.belongsToPlayer = false;
        bullet.direction = direction;
    }
}