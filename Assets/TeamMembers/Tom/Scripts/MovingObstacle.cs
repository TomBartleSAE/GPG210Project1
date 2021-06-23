using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Tom
{
    public class MovingObstacle : NetworkBehaviour
    {
        public float spawnForce; // Force applied when spawned

        public override void OnStartServer()
        {
            base.OnStartServer();
            GetComponent<Rigidbody>().AddRelativeForce(transform.forward * spawnForce); // Push object forward when spawned
        }
    }
}