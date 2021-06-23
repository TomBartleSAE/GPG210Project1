using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class Asteroid : MonoBehaviour
    {
        public GameObject[] smallAsteroids; // Contains prefabs that spawn when object is destroyed, if any
        public float spawnForce; // Force applied when spawned

        private void Start()
        {
            GetComponent<Rigidbody>().AddRelativeForce(transform.forward * spawnForce); // Push object forward when spawned
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.GetComponent<Tim.Bullet>())
            {
                // Check if object breaks into smaller asteroids, this class can be used for the smallest asteroids that don't spawn anything when destroyed
                if (smallAsteroids != null)
                {
                    foreach (GameObject asteroid in smallAsteroids)
                    { 
                        // Spawn each small asteroid, randomly rotate it on the Y-axis
                        Instantiate(asteroid, transform.position, Quaternion.Euler(0, UnityEngine.Random.Range(0f,360f),0));
                    }
                }
                
                Destroy(gameObject);
            }
        }
    }
}