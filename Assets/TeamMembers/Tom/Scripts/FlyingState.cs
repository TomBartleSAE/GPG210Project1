using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class FlyingState : StateBase
    {
        [HideInInspector] public Vector3 targetPosition;
        public float flyingSpeed = 5f;
        [HideInInspector] public bool entered = false;
    
        public override void Enter()
        {
            base.Enter();
            print("Start flying");

            // Assign target position
            // HACK?
            // Entering and exiting state are identical except for the target position, so I've combined them rather than keeping them as separate states
            if (!entered)
            {
                targetPosition = new Vector3(Random.Range(-1f,1f),0,Random.Range(-1f,1f));
            }
            else
            {
                Vector3 exitDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
                exitDirection *= 100f;
                targetPosition = exitDirection;
            }

            // Play spawn sound
        }

        public override void Execute()
        {
            base.Execute();

            // Move ship toward target position
            // Use rigidbody MovePosition instead if you want physics collisions
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, flyingSpeed * Time.deltaTime);
            
            // Play hovering sound
        }

        public override void Exit()
        {
            base.Exit();
        
            print("Stop flying");

            entered = true;
            // Play stopping sound
        }
    }
}