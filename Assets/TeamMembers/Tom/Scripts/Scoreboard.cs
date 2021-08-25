using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tom
{
    public class Scoreboard : MonoBehaviour
    {
        public PlayerStats newPlayerStats;
        private GameManager gameManager;

        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        public void SetupPlayers()
        {
            foreach (LobbyPlayer player in FindObjectOfType<AsteroidNetworkManager>().lobbySlots)
            {
                PlayerStats newPlayer = Instantiate(newPlayerStats, transform);
                newPlayer.SetName(player.name);
            }
        }

        private void OnEnable()
        {
            gameManager.StartGameEvent += SetupPlayers;
        }
        
        private void OnDisable()
        {
            gameManager.StartGameEvent -= SetupPlayers;
        }
    }
}