using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public event Action StartGameEvent;
    public AsteroidNetworkManager asteroidNetworkManager;

    public override void OnStartServer()
    {
        base.OnStartServer();
        asteroidNetworkManager.startingGameEvent += StartGame;
    }

    public void Death()
    {
        print("You have died");
    }

    public void StartGame()
    {
        if (isServer)
        {
            StartGameEvent?.Invoke();
            print("Game Start");
        }
    }

    public void EndGame()
    {
        print("Game End");
    }
}
