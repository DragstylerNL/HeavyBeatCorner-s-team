using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Dictionary<string, GameObject> _players = new Dictionary<string, GameObject>();
    private Enums.GameState[] _playerStates = new Enums.GameState[2];

    public void SetPlayerState(int playerID, Enums.GameState state)
    {
        _playerStates[playerID] = state;
    }

    public Enums.GameState[] GetStates()
    {
        return _playerStates;
    }

    public void RegisterPlayer(string netID, GameObject player)
    {
        _players.Add(netID,player);
    }
}
