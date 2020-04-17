using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCollection : NetworkBehaviour
{
    [SerializeField] private Behaviour[] _toDisable;

    public override void OnStartClient()
    {
        base.OnStartClient();
        GameObject.Find("GameManager").GetComponent<GameManager>().RegisterPlayer(GetComponent<NetworkIdentity>().netId.ToString(), this.gameObject);
    }

    private void Start()
    {
        StartCoroutine(UpdateSearch());
    }
    
    IEnumerator UpdateSearch()
    {
        if (!isLocalPlayer)
        {
            Disable();
            StopCoroutine(UpdateSearch());
        }
        
        yield return new WaitForSeconds(0.5f);
    }

    private void Disable()
    {
        foreach (var b in _toDisable)
        {
            b.enabled = false;
        }
    }
}
