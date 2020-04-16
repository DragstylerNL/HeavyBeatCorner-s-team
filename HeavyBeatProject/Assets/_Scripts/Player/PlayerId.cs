using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerId : MonoBehaviour {
    [SerializeField] private int _playerId;
    
    // References.
    private NetworkIdentity _networkIdentity;


    private void Start() {
        _networkIdentity = FindObjectOfType<NetworkIdentity>();

        // SetPlayerId();
    }

    public int GetPlayerId() {
        return _playerId;
    }

    public void SetPlayerId() {
        // _playerId = id;
        // _playerId = int.Parse(_networkIdentity.netId.ToString());
    }
}
