using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class SpawnManager : NetworkBehaviour
{
    public GameManager gameManager;


    public void OnEnable()
    {
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
 