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
        _audioManager = FindObjectOfType<AudioManager>();
        //_id = GetComponentInParent<PlayerId>().GetPlayerId();
        _id = GetComponent<PlayerDataTransmitter>().id;
        _currentBulletAmount = 3;
    }
    
    void Update() {
        //TODO FIX ON PLAYER
        Debug.DrawRay(transform.position, GetComponentInChildren<Camera>().transform.forward * 10f, Color.blue);
        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }

        if (Input.GetMouseButtonDown(0)) {
            if (_currentBulletAmount <= 0) {
                _audioManager.Play("sfx_gunCharging01");
                return;
            }
            _audioManager.Play("sfx_gunCharging");
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }
    }

    private void Shoot() {
        _audioManager.Stop("sfx_gunCharging");
        if (_currentBulletAmount <= 0) {
            return;
        }
            
        GameObject projectile = Instantiate(_projectile, transform.position, transform.rotation);
        _audioManager.Play("sfx_gunFire02");
        projectile.GetComponent<Projectile>().SetPlayerId(_id);
        projectile.GetComponent<Projectile>().MovementDirection = transform.TransformDirection(Vector3.forward) * _projectileSpeed;
        _currentBulletAmount--;
    }
    
    private void Reload() {
        _audioManager.Play("sfx_gunReload");
        _currentBulletAmount = _bulletAmount;
    }
}
