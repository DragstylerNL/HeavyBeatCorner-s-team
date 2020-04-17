using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 _movementDirection;
    public Vector3 MovementDirection { set { _movementDirection = value; } }
    private int _id;
    
    void Update() {
        transform.position += _movementDirection;
    }

    public void SetPlayerId(int id) {
        _id = id;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            other.gameObject.GetComponent<Enemy>().GotHit();
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Environment")) {
            Destroy(gameObject);
        }
    }
}
