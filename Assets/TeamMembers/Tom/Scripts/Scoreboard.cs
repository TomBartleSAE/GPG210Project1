using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class Scoreboard : MonoBehaviour
    {
        public GameObject newPlayerStats;
        public Transform contentHolder;
        
        public void AddPlayer()
        {
            Instantiate(newPlayerStats, contentHolder);
        }
    }
}