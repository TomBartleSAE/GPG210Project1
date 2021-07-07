using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace Tom
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasAlphaTween : MonoBehaviour
    {
        private CanvasGroup canvas;
    
        private float fadeValue;

        private void Awake()
        {
            canvas = GetComponent<CanvasGroup>();
        }

        public TweenerCore<float, float, FloatOptions> Fade(float startValue, float target, float duration)
        {
            SetFade(startValue);

            
            return DOTween.To(GetFade, SetFade, target, duration);
        }

        private float GetFade()
        {
            return fadeValue;
        }

        private void SetFade(float newValue)
        {
            fadeValue = newValue;
            canvas.alpha = fadeValue;
        }
    }
}