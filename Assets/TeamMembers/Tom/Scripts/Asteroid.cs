using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class Asteroid : MonoBehaviour
    {
        public GameObject[] objectsToSpawn; // Contains prefabs that spawn when object is destroyed, if any
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.GetComponent<Tim.Bullet>())
            {
                foreach (GameObject asteroid in objectsToSpawn)
                { 
                    // Spawn each small asteroid, randomly rotate it on the Y-axis
                    Instantiate(asteroid, transform.position, Quaternion.Euler(0, UnityEngine.Random.Range(0f,360f),0));
                }
                
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            GetComponent<Health>().OnDeath += AsteroidExplosion;
        }

        private void OnDisable()
        {
            GetComponent<Health>().OnDeath -= AsteroidExplosion;
        }

        private void AsteroidExplosion()
        {
            print("Destroyed");
        }
    }
}