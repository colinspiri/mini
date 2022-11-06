using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GiantShoot : MonoBehaviour {
    public GameObject bulletProviderObject;
    
    [Header("Shoot At Player")]
    public Transform gunNozzle;
    public float shootAtPlayerDelay;

    IProvider<Bullet> bulletProvider;
    
    // state
    private float shootCooldown;

    // Start is called before the first frame update
    void Start()
    {
        bulletProvider = bulletProviderObject.GetComponent<IProvider<Bullet>>();
    }

    // Update is called once per frame
    void Update() {
        if (shootCooldown > 0) {
            shootCooldown -= Time.deltaTime;
            return;
        }
        
        ShootAtPlayer();
        shootCooldown = shootAtPlayerDelay;
    }

    private void ShootAtPlayer() {
        Vector3 toPlayer = PlayerMovement.Instance.transform.position - transform.position;
        toPlayer.Normalize();
        ShootBullet(gunNozzle.position, toPlayer);
    }

    private void ShootBullet(Vector3 spawnPosition, Vector3 direction) {
        Bullet bullet = bulletProvider.Get();
        bullet.transform.position = spawnPosition;
        bullet.transform.rotation = Quaternion.identity;
        bullet.belongsToPlayer = false;
        bullet.direction = direction;
    }
}