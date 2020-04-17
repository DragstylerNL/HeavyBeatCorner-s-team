using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour {
    [Tooltip("Drag enemy prefabs here.")]
    [SerializeField] private GameObject[] _enemyPrefabs;
    [Tooltip("Drag spawn locations here")]
    [SerializeField] private List<Locations> _spawnLocations;

    [SerializeField] private List<GameObject> _enemies = new List<GameObject>();

    // Action
    public Action<GameObject> EnemySpawned;

    // References.
    private AudioManager _audioManager;
    
    private void Start() {
        _audioManager = FindObjectOfType<AudioManager>();
    }
    
    private void Update() {
         if (Input.GetKeyDown(KeyCode.S)) {
             SpawnEnemy();
         }
    }

    public void SpawnEnemy() {
        if (_enemies.Count >= 2)
        {
            DestoyEnemies();
        }
        GameObject enemyObject = GetRandomEnemy();
        Locations location = GetRandomLocation();
        for (int i = 0; i < location.dupelicateLocations.Count; i++)
        {
            GameObject enemy = Instantiate(enemyObject);
            enemy.transform.position = location.dupelicateLocations[i].transform.position;
            if (i==0)
            {
                enemy.layer = 8;
                /*Color enemyColor = enemy.GetComponent<MeshRenderer>().material.color;
                enemyColor = new Color(enemyColor.r, enemyColor.g, enemyColor.b, 255f);
                enemy.GetComponent<MeshRenderer>().material.color = enemyColor;*/
            }
            else
            {
                enemy.layer = 9;
                /*Color enemyColor = enemy.GetComponent<MeshRenderer>().material.color;
                enemyColor = new Color(enemyColor.r, enemyColor.g, enemyColor.b, 0f);
                enemy.GetComponent<MeshRenderer>().material.color = enemyColor;*/
            }
            AddEnemyToList(enemy);
        }
        //enemy.transform.position = GetRandomLocation();
        //AddEnemyToList(enemy);
    }

    public void DestoyEnemies()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            Destroy(_enemies[i]);
        }
        _enemies = new List<GameObject>();
    }

    // Adds given enemy to our enemy list.
    private void AddEnemyToList(GameObject obj) {
        _enemies.Add(obj);
    }

    public List<Enemy> GetEnemies()
    {
        List<Enemy> enemies = new List<Enemy>();
        for (int i = 0; i < _enemies.Count; i++)
        {
            enemies.Add(_enemies[i].GetComponent<Enemy>());
        }

        return enemies;
    }

    // Returns how many enemies we currently have in our scene.
    public int GetCurrentEnemyCount() {
        return _enemies.Count;
    }

    // Returns a random enemy prefab.
    private GameObject GetRandomEnemy() {
        return _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)];
    }

    // Returns a random location.
    private Locations GetRandomLocation() {
        return _spawnLocations[Random.Range(0, _spawnLocations.Count)];
    }
}
