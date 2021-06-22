using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MusicManager : NetworkBehaviour
{
    public GameManager GameManager;
    

    public override void OnStartServer()
    {
        base.OnStartServer();
        if (isServer)
        {
            GameManager.StartGameEvent += RpcStartMusic;
        }
    }

    [ClientRpc]
    private void RpcStartMusic()
    {
        Debug.Log("Playing Music");
    }
    
}
