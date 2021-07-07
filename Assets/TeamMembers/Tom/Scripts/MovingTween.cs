using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace Tom
{
    public class MovingTween : MonoBehaviour
    {
        private float positionValue;
        private float target;
        private float duration;

        public TweenerCore<float, float, FloatOptions> Move(float startPos, float endPos, float durationValue)
        {
            SetPosition(startPos);
            target = endPos;
            duration = durationValue;
            
             return DOTween.To(GetPosition, SetPosition, target, duration);
        }

        private float GetPosition()
        {
            return positionValue;
        }

        private void SetPosition(float newValue)
        {
            positionValue = newValue;

            transform.localPosition = new Vector3(0f, newValue, 0f);
        }
    }
}