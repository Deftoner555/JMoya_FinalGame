using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Vector2 shootDirection = (playerMovement.GetMousePosition() - (Vector2)firePoint.position).normalized;

        rb.AddForce(shootDirection * bulletForce, ForceMode2D.Impulse);

        Collider2D bulletCollider = bullet.GetComponent<Collider2D>();
        //bulletCollider.isTrigger = true;
    }

}
