using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class AudioFadeTween : MonoBehaviour
{
    private AudioSource source;

    private float fadeValue;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public TweenerCore<float, float, FloatOptions> Fade(float startVol, float endVol, float duration)
    {
        SetFade(startVol);
        
        return DOTween.To(GetFade, SetFade, endVol, duration);
    }

    private float GetFade()
    {
        return fadeValue;
    }

    private void SetFade(float newValue)
    {
        fadeValue = newValue;
        source.volume = fadeValue;
    }
}
