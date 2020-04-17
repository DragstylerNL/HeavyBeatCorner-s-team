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
    [SyncVar] public float _dayNightCycle = 0;
    private bool _beenActivated = false;
    
    private int lastKnownHealth = -1;
    private NetworkIdentity _identity;
    public int id;
    private DayNightCycler _cycler;

    private void Start()
    {
        _identity = GetComponent<NetworkIdentity>();
        id = int.Parse(_identity.netId.ToString()) - 1;
        _cycler = GameObject.Find("Directional Light ").GetComponent<DayNightCycler>();
    }
    
    private void Update()
    {
        if (lastKnownHealth != health)
        {
            healthtText.text = health.ToString();
            lastKnownHealth = health;
        }

        
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SetStateToActive();
        }

        if (isServer)
        {
            _dayNightCycle = _cycler._sun.rotation.x;
            StateText.text = _dayNightCycle + " ";
            RpcDayNightCycle(_dayNightCycle);
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
    [ClientRpc]
    private void RpcDayNightCycle(float value)
    {
        _dayNightCycle = value;
    }
    
}
