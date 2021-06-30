using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGive : MonoBehaviour
{
    public event Action<int> GiveScoreEvent;

    public void GiveScore(int score)
    {
        GiveScoreEvent?.Invoke(score);
    }
}
