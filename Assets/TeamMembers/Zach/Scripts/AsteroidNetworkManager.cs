using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class AsteroidNetworkManager : NetworkManager
{
    public event Action startingGameEvent;


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
