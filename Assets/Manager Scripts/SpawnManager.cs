using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class SpawnManager : NetworkBehaviour
{
    public GameManager gameManager;


    public void Awake()
    {
        if (isServer)
        {
            gameManager.StartGameEvent += RPCSpawnAsteroids;
        }
    }
    
    [ClientRpc]
    private void RPCSpawnAsteroids()
    {
        Debug.Log("Spawning Asteroids");
    }
}
 