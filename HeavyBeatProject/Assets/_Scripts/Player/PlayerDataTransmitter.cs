using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerDataTransmitter : NetworkBehaviour
{
    public int damage = 10;
    public Text healthtText;

    [SyncVar] public int health = 100;
    [SyncVar] public bool Player1stateActive = false;
    [SyncVar] public bool Player2stateActive = false;
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

    public void TakeDamage()
    {
        if (isServer)
        {
            health = int.Parse(healthtText.text) - damage;
        }
        else
        {
            health = int.Parse(healthtText.text) - damage;
            CmdFunction();
        }
    }

    [Command]
    private void CmdFunction()
    {
        GameManager._players["1"].GetComponent<PlayerDataTransmitter>().health-=damage;
        GameManager._players["2"].GetComponent<PlayerDataTransmitter>().health-=damage;
    }

    public void SetStateToActive(int player)
    {
        CmdSetState(player);
    }

    [Command]
    private void CmdSetState(int player)
    {
        if (player == 1)
        {
            GameManager._players["1"].GetComponent<PlayerDataTransmitter>().Player1stateActive = true;
            GameManager._players["2"].GetComponent<PlayerDataTransmitter>().Player1stateActive = true;
        }
        else if (player == 2)
        {
            GameManager._players["1"].GetComponent<PlayerDataTransmitter>().Player2stateActive = true;
            GameManager._players["2"].GetComponent<PlayerDataTransmitter>().Player2stateActive = true;
        }
    }
    
}
