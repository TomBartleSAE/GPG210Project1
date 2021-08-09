using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Tom
{
    public class Destroyable : MonoBehaviour
    {
        private void OnEnable()
        {
            if (GetComponent<Health>() != null)
            {
                GetComponent<Health>().OnDeathEvent += DestroySelf;
            }
        }

        private void OnDisable()
        {
            if (GetComponent<Health>() != null)
            {
                GetComponent<Health>().OnDeathEvent -= DestroySelf;
            }        
        }


        private void OnTriggerEnter(Collider other)
        {
            // HACK
            // Need a better way to find what objects damage others on collision
            if (other.GetComponent<Health>())
            {
                GetComponent<Health>().CallDamageEvent(1);
            }
        }

        void DestroySelf()
        {
            //Destroy(gameObject);
            NetworkServer.Destroy(gameObject);
        }
    }
}