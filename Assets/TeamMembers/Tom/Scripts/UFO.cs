using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class UFO : MonoBehaviour
    {
        [HideInInspector] public StateBase flyingState, shootingState, deadState;

        private void Start()
        {
            flyingState = GetComponent<FlyingState>();
            shootingState = GetComponent<ShootingState>();
            deadState = GetComponent<DeadState>();

            GetComponent<StateManager>().currentState = flyingState;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.GetComponent<Tim.Bullet>())
            {
                GetComponent<StateManager>().ChangeState(deadState);
            }
        }
    }
}