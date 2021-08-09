using System;
using System.Collections;
using System.Collections.Generic;
using Tom;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    private Health health;
    
    private void Start()
    {
        health = GetComponent<Health>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            health.CallDamageEvent(1);
        }
    }
}
