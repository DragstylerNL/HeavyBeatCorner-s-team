using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 _movementDirection;
    public Vector3 MovementDirection { set { _movementDirection = value; } }

    // Update is called once per frame
    void Update()
    {
        transform.position += _movementDirection;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.CompareTag("Enemy")) {
            other.gameObject.GetComponent<Enemy>().SetPlayerHit(0);
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Environment")) {
            Destroy(gameObject);
        }
    }
}
