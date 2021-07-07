using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioFadeTween titleMusic, gameMusic;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayTitle();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayGame();
        }
    }

    public void PlayTitle()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(gameMusic.Fade(1, 0, 1));
        sequence.Append(titleMusic.Fade(0, 1, 1));
    }

    public void PlayGame()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(titleMusic.Fade(1, 0, 1));
        sequence.Append(gameMusic.Fade(0, 1, 1));
    }
}
