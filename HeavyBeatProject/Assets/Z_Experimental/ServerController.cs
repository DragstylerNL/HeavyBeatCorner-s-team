using UnityEngine;

public class ServerController : MonoBehaviour
{
    private Server _server;
    private Client _client;
    
    // Start is called before the first frame update
    void Start()
    {
        _server = GetComponent<Server>();
        _client = GetComponent<Client>();
    }

    public void StartServer()
    {
        _server.StartServer();
    }

    public void StartClient()
    {
        _client.StartClient();
    }

    public void SendMessageToServer()
    {
        _client.SendMessageToServer("DAAAAHLINGG");
    }
}
