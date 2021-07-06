using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenTest : MonoBehaviour
{
    public AnimationCurve Curve1;
    private float timer;

    public float scale, target, duration;
    
    private void Start()
    {
        DOTween.To(GetScale, SetScale, target, duration).SetEase(Ease.OutElastic).OnComplete(FinishScaling);
        //transform.DOShakePosition(5, 5, 1000, 1000, true, true);
    }

    public void Update()
    {
        
        timer += Time.deltaTime;
        float animatedValue = Curve1.Evaluate(timer);


        // Simple scale for example
        transform.localScale = new Vector3(animatedValue, animatedValue, animatedValue);

        if (timer>= Curve1.length)
        {
            // It's over
            print("END");
        }
        
    }

    private void SetScale(float newValue)
    {
        scale = newValue;
        
        transform.localScale = new Vector3(scale, scale, scale);
    }

    private float GetScale()
    {
        return scale;
    }

    private void FinishScaling()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
