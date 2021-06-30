using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Tom;
using Unity.VisualScripting;

public class MusicManager : NetworkBehaviour
{
    public GameManager GameManager;
    private Health health;

    private void Start()
    {
        
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        if (isServer)
        {
            health = FindObjectOfType<Health>();
            GameManager.StartGameEvent += RpcStartMusic;
            health.OnDeathEvent += RpcDeath;
        }
    }

    [ClientRpc]
    private void RpcStartMusic()
    {
        Debug.Log("Playing Music");
    }

    private void RpcDeath()
    {
        Debug.Log("You Died");
    }
}
