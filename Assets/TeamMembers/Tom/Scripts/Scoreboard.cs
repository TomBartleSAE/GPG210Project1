using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class Scoreboard : MonoBehaviour
    {
        public PlayerStats newPlayerStats;
        
        public void AddPlayer()
        {
            PlayerStats newPlayer = Instantiate(newPlayerStats, transform);
            
            // Consider getting player number from a list of all player objects rather than child count
            // Could also assign a colour to each player and pass the name of that colour here?
            newPlayer.SetName("Player " + (transform.childCount - 1));
        }
    }
}