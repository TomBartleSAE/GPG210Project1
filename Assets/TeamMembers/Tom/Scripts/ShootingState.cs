using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using Random = System.Random;

namespace Tom
{
    public class ShootingState : StateBase
    {
        private float nextFire;
        public float fireRate = 1f;
        public float shootingTimer = 5f;
        public GameObject bulletPrefab;
        
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
            nextFire -= Time.deltaTime;
            if (nextFire <= 0)
            {
                if (bulletPrefab != null)
                {
                    GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, UnityEngine.Random.Range(0f,360f), 0));
                    NetworkServer.Spawn(newBullet);
                }
                nextFire = 1 / fireRate;
            }

            shootingTimer -= Time.deltaTime;
        }

        public override void Exit()
        {
            base.Exit();

            print("Stop shooting");
        }
    }
}