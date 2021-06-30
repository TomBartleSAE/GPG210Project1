using System;
using System.Collections;
using System.Collections.Generic;
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
            if (other.GetComponent<Tim.Bullet>())
            {
                if (GetComponent<Health>())
                {
                    GetComponent<Health>().Die();
                }
            }
        }

        void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}