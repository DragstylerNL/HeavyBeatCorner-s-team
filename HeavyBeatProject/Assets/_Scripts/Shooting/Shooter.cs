using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script on the player camera/gun, not the player object.
public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _projectileSpeed = 0.1f;
    [SerializeField] private int _bulletAmount = 3;
    [SerializeField] private int _currentBulletAmount;

    void Start()
    {
        Reload();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.blue);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }
    }

    private void Shoot()
    {
        if (_currentBulletAmount <= 0) return;
            
        GameObject projectile = Instantiate(_projectile, transform.position, transform.rotation);
        projectile.GetComponent<Projectile>().MovementDirection = transform.TransformDirection(Vector3.forward) * _projectileSpeed;
        _currentBulletAmount--;
    }
    
    private void Reload()
    {
        _currentBulletAmount = _bulletAmount;
    }
}
