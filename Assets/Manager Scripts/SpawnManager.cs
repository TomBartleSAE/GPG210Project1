using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class SpawnManager : NetworkBehaviour
{
    public GameManager gameManager;

    //On start server works since it relies on the server starting and allows for the code to run properly 
    public override void OnStartServer()
    {
        base.OnStartServer();
        
        if (isServer)
        {
            gameManager.StartGameEvent += RpcSpawnAsteroids;
        }
    }

    [ClientRpc]
    public void RpcSpawnAsteroids()
    {
        Debug.Log("Spawning Asteroids");
    }
}
 