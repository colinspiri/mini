using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public KeyCode shootKey;
    public GameObject bulletProviderObject;
    public Transform spawnPosition;
    public float shootDelay;

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
        
        if (Input.GetKey(shootKey)) { 
            ShootBullet();
            shootCooldown = shootDelay;
        }
    }

    private void ShootBullet() {

        Bullet bullet = bulletProvider.Get();
        bullet.transform.position = spawnPosition.position;
        bullet.transform.rotation = Quaternion.identity;
        bullet.belongsToPlayer = true;
        bullet.direction = PlayerMovement.Instance.aimDirection;
    }
}
