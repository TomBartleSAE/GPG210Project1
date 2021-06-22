using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class ShootingState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
        
            print("Start shooting");
        }

        public override void Execute()
        {
            base.Execute();
        
            // Countdown timer until next fire
            // When timer reaches 0, fire in random direction and reset timer
        
            // Countdown timer until stop shooting
        }

        public override void Exit()
        {
            base.Exit();

            print("Stop shooting");
        }
    }
}