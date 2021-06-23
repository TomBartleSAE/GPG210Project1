using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tim
{
    public class Bullet : MonoBehaviour
    {
        public Rigidbody rb;

        public GameObject Asteroid;
    // Start is called before the first frame update
     void Start()
     {
         rb = GetComponent<Rigidbody>();
         rb.AddRelativeForce(new Vector3(100,0,0));
     }

    // Update is called once per frame
     void Update()
        {
            
        }

     private void OnCollisionEnter(Collision other)
     {
         if (other.collider == Asteroid.GetComponent<Collider>())
         {
             Debug.Log("Hit Asteroid");
             Destroy(this);
         }
     }
    }
}

