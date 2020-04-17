using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerDataTransmitter : NetworkBehaviour
{
    public int damage = 10;
    public Text healthtText;
    public Text StateText;

    [SyncVar] public int health = 100;
    [SyncVar] public int Playerstate = 0;
    private bool _beenActivated = false;
    
    private int lastKnownHealth = -1;
    private NetworkIdentity _identity;

    private void Start()
    {
        _identity = GetComponent<NetworkIdentity>();
    }

    private void Update()
    {
        if (lastKnownHealth != health)
        {
            healthtText.text = health.ToString();
            lastKnownHealth = health;
        }

        StateText.text = Playerstate.ToString();
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SetStateToActive();
        }
    }

    public void TakeDamage()
    {
        health = int.Parse(healthtText.text) - damage;
        if (!isServer)
        {
            CmdFunction();
        }
    }

    [Command]
    private void CmdFunction()
    {
        GameManager._players["1"].GetComponent<PlayerDataTransmitter>().health-=damage;
        GameManager._players["2"].GetComponent<PlayerDataTransmitter>().health-=damage;
    }

    public void SetStateToActive()
    {
        if (_beenActivated) return;
        _beenActivated = true;
        Playerstate++;
        if (!isServer)
        {
            CmdSetState(1);
        }
        StartCoroutine(StateTimer());
    }

    [Command]
    private void CmdSetState(int value)
    {
        GameManager._players["1"].GetComponent<PlayerDataTransmitter>().Playerstate+=value;
        GameManager._players["2"].GetComponent<PlayerDataTransmitter>().Playerstate+=value;
    }

    IEnumerator StateTimer()
    {
        yield return new WaitForSeconds(0.8f);
        _beenActivated = false;
        Playerstate--;
        if (!isServer)
        {
            CmdSetState(-1);
        }
    }

    [ClientRpc]
    private void RpcSetState()
    {
        Playerstate = 1;
    }
    
}
