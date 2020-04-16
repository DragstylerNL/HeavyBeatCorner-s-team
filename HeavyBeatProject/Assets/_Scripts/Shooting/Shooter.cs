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
    [SerializeField] private int _id;
    
    // References
    private AudioManager _audioManager;

    void Start() {
        Reload();
        _id = GetComponentInParent<PlayerId>().GetPlayerId();
        _audioManager = FindObjectOfType<AudioManager>();
    }
    
    void Update() {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.blue);
        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }

        if (Input.GetMouseButtonDown(0)) {
            _audioManager.Play("sfx_gunCharging");
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }
    }

    private void Shoot() {
        _audioManager.Stop("sfx_gunCharging");
        if (_currentBulletAmount <= 0) {
            _audioManager.Play("sfx_gunEmpty");
            return;
        }
            
        GameObject projectile = Instantiate(_projectile, transform.position, transform.rotation);
        _audioManager.Play("sfx_gunFire02");
        projectile.GetComponent<Projectile>().SetPlayerId(_id);
        projectile.GetComponent<Projectile>().MovementDirection = transform.TransformDirection(Vector3.forward) * _projectileSpeed;
        _currentBulletAmount--;
    }
    
    private void Reload()
    {
        _currentBulletAmount = _bulletAmount;
    }
}
