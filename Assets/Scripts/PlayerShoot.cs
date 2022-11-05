using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public KeyCode shootKey;
    public GameObject bulletPrefab;
    public Transform spawnPosition;
    public float shootDelay;
    
    // state
    private float shootCooldown;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Bullet bullet = Instantiate(bulletPrefab, spawnPosition.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.belongsToPlayer = true;
        bullet.direction = PlayerMovement.Instance.aimDirection;
    }
}
