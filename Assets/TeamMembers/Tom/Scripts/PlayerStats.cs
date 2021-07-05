using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tom
{
    public class PlayerStats : MonoBehaviour
    {
        public Text nameText, livesText, scoreText;

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
            nameText.text = newScore.ToString();
        }
    }
}