using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class UFO : MonoBehaviour
    {
        [HideInInspector] public FlyingState flyingState;
        [HideInInspector] public ShootingState shootingState; 
        [HideInInspector] public DeadState deadState;

        private StateManager stateManager;

        private void Start()
        {
            // Get all UFO states
            flyingState = GetComponent<FlyingState>();
            shootingState = GetComponent<ShootingState>();
            deadState = GetComponent<DeadState>();

            // Set default state to flying
            stateManager = GetComponent<StateManager>();
            stateManager.currentState = flyingState;
        }

        private void Update()
        {
            // HACK?
            if (flyingState)
            {
                if (transform.position == flyingState.targetPosition)
                {
                    stateManager.ChangeState(shootingState);
                }
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            // Set state to dead if UFO touches bullet
            if (other.collider.GetComponent<Tim.Bullet>())
            {
                GetComponent<StateManager>().ChangeState(deadState);
            }
        }
    }
}