using System;
using Mirror;

public class GameManager : NetworkBehaviour
{
    public AsteroidNetworkManager asteroidNetworkManager;
    public event Action StartGameEvent;

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