using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    [SerializeField] private SpawnController _spawnController;

    void Update()
    {
        CheckEnemies();
    }

    private void CheckEnemies()
    {
        if (_spawnController.GetEnemies().Count != 2) return;
        
        List<Enemy> enemies = _spawnController.GetEnemies();
        
        if (enemies[0].IGotHit && enemies[1].IGotHit)
        {
            _spawnController.DestoyEnemies();
        }
    }
}
