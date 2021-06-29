using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class FlyingState : StateBase
    {
        public Vector3 targetPosition;
        public float flyingSpeed;
    
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
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, flyingSpeed * Time.deltaTime);
            
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