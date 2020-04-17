using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyShaderSpawn : MonoBehaviour {
    private float _maxValue = 1.3f;
    private Renderer _renderer;
    private bool _isAnimating = false;

    private void Start() {
        _renderer = GetComponent<Renderer>();
        _isAnimating = true;
    }

    private void Update() {
        if (_isAnimating) {
            ShaderSpawnAnimation();
        }
    }
    

    private void ShaderSpawnAnimation() {
        if (_renderer == null) {
            return;
        }

        float f = _renderer.material.GetFloat("Position");
        if (f > _maxValue) {
            _isAnimating = false;
            return;
        }

        if (f > _maxValue / 2) {
            // Disables edge thickness.
            _renderer.material.SetFloat("Edge", 0);
        }
        f += Time.deltaTime * 1f;
        _renderer.material.SetFloat("Position", f);
    }
}
