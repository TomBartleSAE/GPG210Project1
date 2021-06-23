using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class MovingObstacle : MonoBehaviour
    {
        public float spawnForce; // Force applied when spawned

        private void Start()
        {
            GetComponent<Rigidbody>().AddRelativeForce(transform.forward * spawnForce); // Push object forward when spawned
        }
    }
}