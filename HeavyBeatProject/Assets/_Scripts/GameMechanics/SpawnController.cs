using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour {
    [Tooltip("Drag enemy prefabs here.")]
    [SerializeField] private GameObject[] _enemyPrefabs;
    [Tooltip("Drag spawn locations here")] 
    [SerializeField] private GameObject[] _spawnLocations;

    private List<GameObject> _enemies = new List<GameObject>();
    
    // Action
    public Action<GameObject> EnemySpawned;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.B)) {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy() {
        GameObject enemy = Instantiate(GetRandomEnemy());
        enemy.transform.position = GetRandomLocation();
        AddEnemyToList(enemy);
        
        if (EnemySpawned != null) {
            EnemySpawned(enemy);
        }
    }

    // Adds given enemy to our enemy list.
    private void AddEnemyToList(GameObject obj) {
        _enemies.Add(obj);
    }

    // Returns how many enemies we currently have in our scene.
    private int GetCurrentEnemyCount() {
        return _enemies.Count;
    }
    
    // Returns a random enemy prefab.
    private GameObject GetRandomEnemy() {
        return _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)];
    }

    // Returns a random location.
    private Vector3 GetRandomLocation() {
        return _spawnLocations[Random.Range(0, _spawnLocations.Length)].transform.position;
    }
}
