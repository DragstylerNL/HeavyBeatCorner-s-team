using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FailureState : MonoBehaviour {
    [Tooltip("How long do the players have time to kill the enemy?")] 
    [SerializeField] private float _killTime = 10f;
    [Tooltip("Drag Text Mesh Pro UI object here.")]
    [SerializeField] private TextMeshProUGUI _counterText;
    
    private List<GameObject> _enemies = new List<GameObject>();
    private float _counter;
    
    // Action
    public Action FailedToKillEnemy;
    
    // References.
    private SpawnController _spawnController;
    private AudioManager _audioManager;

    private void Start() {
        _spawnController = FindObjectOfType<SpawnController>();
        _spawnController.EnemySpawned += AddEnemyToList;
        _audioManager = FindObjectOfType<AudioManager>();

        ResetCounter();
        HideCounter();
    }

    private void Update() {
        if (_enemies.Count > 0) {
            ShowCounter();
            Countdown();
        }

        if (_enemies.Count <= 0) {
            HideCounter();
        }
    }

    // Counts down and adjusts UI element.
    private void Countdown() {
        if (_counter <= 0) {
            RemoveEnemyFromList();
            ResetCounter();
            _audioManager.Play("sfx_enemyMistTransform");
            
            if (FailedToKillEnemy != null) {
                FailedToKillEnemy();
            }
            return;
        }
        
        _counter -= Time.deltaTime;
        _counterText.text = (Mathf.Round(_counter)).ToString();
    }

    // Resets text element back to default value.
    private void ResetCounter() {
        _counter = _killTime;
        _counterText.text = (Mathf.Round(_counter)).ToString();
    }

    private void HideCounter() {
        _counterText.gameObject.SetActive(false);
    }

    private void ShowCounter() {
        _counterText.gameObject.SetActive(true);
    }

    // Removes the first enemy from list.
    private void RemoveEnemyFromList() {
        _enemies.Remove(_enemies[0]);
    }

    // Add given enemy to list.
    private void AddEnemyToList(GameObject obj) {
        _enemies.Add(obj);
    }

    // Unsubscribe from event.
    private void OnDestroy() {
        _spawnController.EnemySpawned -= AddEnemyToList;
    }
}
