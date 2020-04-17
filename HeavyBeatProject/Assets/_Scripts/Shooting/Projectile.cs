using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 _movementDirection;
    public Vector3 MovementDirection { set { _movementDirection = value; } }
    private int _id;
    
    // References.
    private AudioManager _audioManager;

    private void Start() {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    void Update() {
        transform.position += _movementDirection;
    }

    public void SetPlayerId(int id) {
        _id = id;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            //other.gameObject.GetComponent<Enemy>().GotHit();
            //Destroy(gameObject);
            StartCoroutine(CheckActiveState(other.gameObject));
        } else if (other.gameObject.CompareTag("Environment")) {
            _audioManager.Play("sfx_wallHit");
            Destroy(gameObject);
        }
    }

    private IEnumerator CheckActiveState(GameObject enemy)
    {
        float timer = 1f;
        PlayerDataTransmitter player1 = GameManager._players[("1")].GetComponent<PlayerDataTransmitter>();
        PlayerDataTransmitter player2 = GameManager._players[("2")].GetComponent<PlayerDataTransmitter>();
        
        if (_id == 0)
        {
            player1.SetStateToActive();
        }
        else
        {
            player2.SetStateToActive();
        }
        
        while (timer >= 0f)
        {
            timer -= Time.deltaTime;
            if (player1.Playerstate == 2)
            {
                Destroy(enemy);
                StopCoroutine(CheckActiveState(null));
            }
        }
        yield return new WaitForEndOfFrame();
    }
}
