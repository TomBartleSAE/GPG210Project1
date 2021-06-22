using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class FlyingState : StateBase
    {
        private Vector3 targetPosition;
    
        public override void Enter()
        {
            base.Enter();
            print("Start flying");

            // Assign target position
            // Play spawn sound
        }

        public override void Execute()
        {
            base.Execute();
        
            // Move ship toward target position
            // Checking if ship has reached target position
            // Play hovering sound
        }

        public override void Exit()
        {
            base.Exit();
        
            print("Stop flying");
        
            // Stop moving
            // Play stopping sound
        }
    }
}