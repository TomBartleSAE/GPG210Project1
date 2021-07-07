using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tom
{
    public class MovingObstacle : NetworkBehaviour
    {
        public float minSpawnForce, maxSpawnForce; // Force applied when spawned
        
        
        /*
        public override void OnStartServer()
        {
            base.OnStartServer();
            GetComponent<Rigidbody>().AddRelativeForce(transform.forward * spawnForce); // Push object forward when spawned
        }
        */

        private void Start()
        {
            transform.rotation = Quaternion.Euler(0, Random.Range(0,360), 0);
            GetComponent<Rigidbody>().velocity = transform.forward * Random.Range(minSpawnForce, maxSpawnForce); // Push object forward when spawned
        }
    }
}