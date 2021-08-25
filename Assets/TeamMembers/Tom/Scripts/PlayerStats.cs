using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace Tom
{
    public class PlayerStats : MonoBehaviour
    {
        public Text nameText, livesText, scoreText;
        public NetworkIdentity id;
        public int currentScore = 0;

        public void SetName(string newName)
        {
            nameText.text = newName;
        }

        public void SetLives(int newLives)
        {
            livesText.text = newLives.ToString();
        }

        public void SetScore(int newScore)
        {
            scoreText.text = newScore.ToString();
        }
    }
}