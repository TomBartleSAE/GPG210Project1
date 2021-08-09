using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Tim;
using UnityEngine;

namespace Tom
{
    public class Asteroid : NetworkBehaviour
    {
        public GameObject[] objectsToSpawn; // Contains prefabs that spawn when object is destroyed, if any
        private Health health;
        //private Spawner aSpawner;
        private void OnEnable()
        {
            if (GetComponent<Health>() != null)
            {
                health = GetComponent<Health>();
                health.OnDeathEvent += AsteroidExplosion;
            }

            //if (FindObjectOfType<Spawner>() !=null)
            {
                //aSpawner = FindObjectOfType<Spawner>().GetComponent<Spawner>();
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
                //aSpawner.asteroidSpawn(asteroid,transform.position);
                GameObject newAsteroid = Instantiate(asteroid, transform.position, Quaternion.identity);
                NetworkServer.Spawn(newAsteroid);
                // Spawn each small asteroid, randomly rotate it on the Y-axis
            }
        }
    }
}