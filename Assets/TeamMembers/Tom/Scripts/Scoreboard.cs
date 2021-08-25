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
        public PlayerStats playerStatsPrefab;
        public List<PlayerStats> playerList = new List<PlayerStats>();
        private GameManager gameManager;
        private ScoreManager scoreManager;
        private AsteroidNetworkManager networkManager;

        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
            scoreManager = FindObjectOfType<ScoreManager>();
            networkManager = FindObjectOfType<AsteroidNetworkManager>();
        }

        public void SetupPlayers()
        {
            foreach (NetworkIdentity player in FindObjectOfType<AsteroidNetworkManager>().networkIdentities)
            {
                PlayerStats newPlayer = Instantiate(playerStatsPrefab, transform);
                playerList.Add(newPlayer);
                newPlayer.SetName(player.name);
                newPlayer.id = player;
                player.GetComponent<Health>().OnDeathEvent += SetLives;
            }
            
            SetLives();
        }

        public void SetLives()
        {
            // HACK
            foreach (PlayerStats player in playerList)
            {
                player.SetLives(player.id.GetComponent<Health>().lives);
            }
        }

        public void AddScore(int score, NetworkIdentity identity)
        {
            foreach (PlayerStats player in playerList)
            {
                if (player.id == identity)
                {
                    player.currentScore += score;
                    player.SetScore(player.currentScore);
                    break;
                }
            }
        }

        private void OnEnable()
        {
            gameManager.StartGameEvent += SetupPlayers;
            scoreManager.scoreEvent += AddScore;
        }
        
        private void OnDisable()
        {
            gameManager.StartGameEvent -= SetupPlayers;
            scoreManager.scoreEvent -= AddScore;

            foreach (PlayerStats player in playerList)
            {
                player.GetComponent<Health>().OnDeathEvent -= SetLives;
            }
        }
    }
}