using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class Asteroid : MonoBehaviour
    {
        public GameObject[] objectsToSpawn; // Contains prefabs that spawn when object is destroyed, if any
        private Health health;

        private void OnEnable()
        {
            if (GetComponent<Health>() != null)
            {
                health = GetComponent<Health>();
                health.OnDeathEvent += AsteroidExplosion;
            }
        }

        private void OnDisable()
        {
            if (GetComponent<Health>() != null)
            {
                health.OnDeathEvent -= AsteroidExplosion;
            }
        }

        private void AsteroidExplosion()
        {
            foreach (GameObject asteroid in objectsToSpawn)
            { 
                // Spawn each small asteroid, randomly rotate it on the Y-axis
                Instantiate(asteroid, transform.position, Quaternion.Euler(0, UnityEngine.Random.Range(0f,360f),0));
            }
        }
    }
}