using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class StateManager : MonoBehaviour
    {
        public StateBase currentState;

        public void ChangeState(StateBase newState)
        {
            if (currentState != null)
            {
                currentState.Exit(); // Exit previous state
            }
            
            currentState = newState; // Set current state to the new state
            currentState.Enter(); // Enter the new state
        }

        private void Update()
        {
            if (currentState != null)
            {
                currentState.Execute();
            }
        }
    }
}