using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class AsteroidNetworkManager : NetworkManager
{
    public List<NetworkConnection> lobbyPlayers = new List<NetworkConnection>();

    [Header("Lobby")] [SerializeField] public GameObject playerAsteroidPrefab;

    public List<GameObject> lobbySlots = new List<GameObject>();

    public List<NetworkIdentity> networkIdentities = new List<NetworkIdentity>();

    public LobbyUI lobbyUI;
    public event Action startingGameEvent;

    public override void OnStartServer()
    {
        base.OnStartServer();
        //StartCoroutine(StartGameMode());
        // startingGameEvent?.Invoke();
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        //Base connecting to server code
        base.OnServerConnect(conn);
        lobbyPlayers.Add(conn);

        //Lobby specific code
        GameObject lobbyPlayerInstance = Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, lobbyPlayerInstance.gameObject);
        lobbySlots.Add(lobbyPlayerInstance);
        lobbyPlayerInstance.name = conn.connectionId.ToString();
        lobbyUI.UpdateUserPanel();
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        base.OnServerDisconnect(conn);
        lobbyPlayers.Remove(conn);
        lobbyPlayers.Remove(playerPrefab.GetComponent<NetworkConnection>());
    }

    public void SpawnPlane()
    {
        foreach (NetworkConnection player in lobbyPlayers)
        {
            Transform spawnPos = GetStartPosition();
            GameObject playerInstance = spawnPos != null
                ? Instantiate(playerAsteroidPrefab, spawnPos.position, spawnPos.rotation)
                : Instantiate(playerPrefab);
            networkIdentities.Add(playerInstance.GetComponent<NetworkIdentity>());
            NetworkServer.ReplacePlayerForConnection(player, playerInstance, true);
        }

        startingGameEvent?.Invoke();
    }


    public IEnumerator StartGameMode()
    {
        yield return new WaitForSeconds(0.5f);

        startingGameEvent?.Invoke();
    }
}