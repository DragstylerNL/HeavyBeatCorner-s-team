using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerDataTransmitter : NetworkBehaviour
{
    public int damage = 10;
    public Text healthtText;

    [SyncVar] public int health = 100;
    [SyncVar] public int State = 0;
    private int lastKnownHealth = -1;

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
    }

    private void TakeDamage()
    {
        if (isServer)
        {
            health = int.Parse(healthtText.text) - damage;
        }
        else
        {
            health = int.Parse(healthtText.text) - damage;
            CmdFunction(health);
        }
    }
    
    [Command]
    public void CmdFunction(int value)
    {
        GameManager._players["1"].GetComponent<PlayerDataTransmitter>().health-=damage;
        GameManager._players["2"].GetComponent<PlayerDataTransmitter>().health-=damage;
    }
}
