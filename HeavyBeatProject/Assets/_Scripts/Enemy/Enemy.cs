using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //[SerializeField] private int _amountOfPlayers = 2;
    [SerializeField] private float _leewayTime = 0.8f;
    private float _leewayCounter = 0f;
    private bool _isCountingLeeway = false;
    private bool _iGotHit = false;
    public bool IGotHit { get { return _iGotHit; } }
    //[SerializeField] private GameObject[] _players;
    //private Dictionary<GameObject, bool> _playerHitMap;

    [SerializeField] private GameObject[] _players;
    private Dictionary<GameObject, bool> _playerHitMap;
    
    // References.
    private AudioManager _audioManager;

    private void Start() {
        //InitializePlayerHitMap();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update() {
        /*if (Input.GetKeyDown(KeyCode.X)) {
            SetPlayerHit(0);
        }*/

        if (_isCountingLeeway) {
            if (_leewayCounter >= _leewayTime) {
                ResetLeewayCounter();
                _iGotHit = false;
                //ResetPlayerHit();
                return;
            }
            
            _leewayCounter += Time.deltaTime;
        }
    }

    public void GotHit()
    {
        _iGotHit = true;
        _isCountingLeeway = true;
        _audioManager.Play("sfx_enemyHit");
    }
    
    /*private void InitializePlayerHitMap() {
        _playerHitMap = new Dictionary<GameObject, bool>();
        
        for (int i = 0; i < _amountOfPlayers; i++) {
            _playerHitMap[_players[i]] = false;
        }
    }

    private void ResetPlayerHit() {
        for (int i = 0; i < _amountOfPlayers; i++) { 
            _playerHitMap[_players[i]] = false;
        }
    }

    public void SetPlayerHit(int id) {
        _playerHitMap[_players[id]] = true;
        CheckIfDestroy();
    }*/

    /*private void CheckIfDestroy() {
        bool check = AllPlayerHit();
        _isCountingLeeway = true;
        print("All players hit = " + check);
        

        //  && _leewayCounter > 0 && _leewayCounter < _leewayTime
        if (check && _leewayCounter > 0 && _leewayCounter < _leewayTime) {
            print("Destroying enemy");
            DestroyUnit();
        }
    }*/
    private void DestroyUnit() {
        _audioManager.Play("sfx_enemyDeath");
        Destroy(gameObject);
    }

    /*private bool AllPlayerHit() {
        for (int i = 0; i < _amountOfPlayers; i++) {
            if (!_playerHitMap[_players[i]]) {
                print("Player " + (i + 1) + " hit is " + _playerHitMap[_players[i]]);
                _audioManager.Play("sfx_enemyHit");
                return false;
            }
            print("Player " + (i + 1) + " hit is " + _playerHitMap[_players[i]]);
        }

        return true;
    }*/

    private void ResetLeewayCounter() {
        _leewayCounter = 0f;
        _isCountingLeeway = false;
    }


}
