using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathMist : MonoBehaviour {
    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private float _waitForSeconds = 3f;
    [SerializeField] private float _destroyTime = 5f;
    [SerializeField] private float _timer;

    private void Start() {
        _timer = 0f;
    }

    private void Update() {
        _timer += Time.deltaTime;

        if (_timer >= _waitForSeconds) {
            StopParticles();
        }

        if (_timer >= _destroyTime) {
            Destroy(gameObject);
        }
    }

    private void StopParticles() {
        foreach (ParticleSystem p in _particleSystems) {
            p.Stop();
        }
    }
}
