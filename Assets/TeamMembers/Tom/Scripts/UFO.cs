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

        public StateManager stateManager;

        private void Start()
        {
            // Get all UFO states
            flyingState = GetComponent<FlyingState>();
            shootingState = GetComponent<ShootingState>();
            deadState = GetComponent<DeadState>();

            // Set default state to flying
            stateManager = GetComponent<StateManager>();
            stateManager.ChangeState(flyingState);
        }

        private void Update()
        {
            // HACK
            // This would be problematic if you had lots of states
            // Consider changing transition conditions in each state
            if (stateManager.currentState == flyingState)
            {
                if (transform.position == flyingState.targetPosition && !flyingState.entered)
                {
                    stateManager.ChangeState(shootingState);
                }
            }
            if (stateManager.currentState == shootingState)
            {
                if (shootingState.shootingTimer <= 0)
                {
                    stateManager.ChangeState(flyingState);
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