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
        private float target;
        private float duration;

        private void Awake()
        {
            canvas = GetComponent<CanvasGroup>();
        }

        public TweenerCore<float, float, FloatOptions> Fade(float startValue, float targetValue, float durationValue)
        {
            SetFade(startValue);
            target = targetValue;
            duration = durationValue;
            
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