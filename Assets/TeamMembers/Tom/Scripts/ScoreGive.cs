using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGive : MonoBehaviour
{
    [SerializeField] private int scoreValue;

    public int GetScore()
    {
        return scoreValue;
    }
}
