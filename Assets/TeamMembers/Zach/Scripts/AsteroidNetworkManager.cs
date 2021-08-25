using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class AsteroidNetworkManager : NetworkManager
{
    public event Action startingGameEvent;

    public List<NetworkConnection> lobbyPlayers = new List<NetworkConnection>();
    
    [Header("Lobby")]
    [SerializeField] public LobbyPlayer roomPlayerPrefab = null;

    public List<LobbyPlayer> lobbySlots = new List<LobbyPlayer>();


    public override void OnServerConnect(NetworkConnection conn)
    {
        //Base connecting to server code
        base.OnServerConnect(conn);
        lobbyPlayers.Add(conn);
        
        //Lobby specific code
        LobbyPlayer lobbyPlayerInstance = Instantiate(roomPlayerPrefab);
        NetworkServer.AddPlayerForConnection(conn, lobbyPlayerInstance.gameObject);
        lobbySlots.Add(lobbyPlayerInstance);
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        base.OnServerDisconnect(conn);
        lobbyPlayers.Remove(conn);
        lobbyPlayers.Remove(roomPlayerPrefab.connectionToServer);
    }

    public void SpawnPlane()
    {
        foreach (NetworkConnection player in lobbyPlayers)
        {
            Transform spawnPos = GetStartPosition();
            GameObject playerInstance = spawnPos != null
                ? Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation)
                : Instantiate(playerPrefab);
            NetworkServer.ReplacePlayerForConnection(player, playerInstance, true);
        }
    }
    
    
    public override void OnStartServer()
    {
        base.OnStartServer();
        StartCoroutine(StartGameMode());
        // startingGameEvent?.Invoke();
    }

    public IEnumerator StartGameMode()
    {
        yield return new WaitForSeconds(0.5f);
        
        startingGameEvent?.Invoke();
    }
}
