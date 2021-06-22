using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class DeadState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            print("Start dying");
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Exit()
        {
            base.Exit();
            
            print("Stop dying");
        }
    }
}