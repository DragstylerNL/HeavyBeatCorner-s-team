using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCollection : NetworkBehaviour
{
    [SerializeField] private PlayerMovent _playerMovent;

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
        GetComponentInChildren<Camera>().enabled = false;
        _playerMovent.enabled = false;
    }
}
