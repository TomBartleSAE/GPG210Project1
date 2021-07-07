using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action StartGameEvent; 
    
    public void Death()
    {
        print("You have died");
    }

    public void StartGame()
    {
        StartGameEvent?.Invoke();
        print("Game Start");
    }

    public void EndGame()
    {
        print("Game End");
    }
}
