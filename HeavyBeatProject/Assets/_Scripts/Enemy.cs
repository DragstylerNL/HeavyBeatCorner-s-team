using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private int _amountOfPlayers = 2;

    [SerializeField] private GameObject[] _players;
    private Dictionary<GameObject, bool> _playerHitMap;


    private void Start() {
        InitializePlayerHitMap();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            SetPlayerHit(0);
        }
    }

    private void InitializePlayerHitMap() {
        _playerHitMap = new Dictionary<GameObject, bool>();
        
        for (int i = 0; i < _amountOfPlayers; i++) {
            _playerHitMap[_players[i]] = false;
            print("Player " + i + "value: " + _playerHitMap[_players[i]]);
        }
    }

    private void SetPlayerHit(int id) {
        _playerHitMap[_players[id]] = true;
        print("Player " + _players[id].gameObject.name + " has hit " + gameObject);
        CheckIfDestroy();
    }

    private void CheckIfDestroy() {
        bool check = false;
        
        for (int i = 0; i < _amountOfPlayers; i++) {
            if (_playerHitMap[_players[i]]) {
                check = true;
            }
            else {
                check = false;
            }
        }

        if (check) {
            Destroy(gameObject);
            return;
        }

        print("Not yet destroyed");
    }
}
