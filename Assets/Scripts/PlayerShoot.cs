using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public KeyCode shootKey;
    public GameObject bulletPrefab;
    public Transform spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(shootKey)) { 
            ShootBullet();  
        }
    }

    private void ShootBullet() {
        Bullet bullet = Instantiate(bulletPrefab, spawnPosition).GetComponent<Bullet>();
        bullet.InitializeBullet(PlayerMovement.Instance.direction, true);
    }
}
