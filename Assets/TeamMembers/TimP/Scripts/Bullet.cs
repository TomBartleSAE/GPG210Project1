using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Tom;
using UnityEngine;

namespace Tim
{
    public class Bullet : NetworkBehaviour
    {
        public Rigidbody rb;
        public GameObject Asteroid;
        public float dTimer;
    // Start is called before the first frame update
     void Start()
     {
         rb = GetComponent<Rigidbody>();
         rb.AddRelativeForce(new Vector3(100,0,0));
     }

    // Update is called once per frame
    private void FixedUpdate()
    {
        dTimer = dTimer - Time.deltaTime;
        if (dTimer <=0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
     {
         if (other.gameObject.CompareTag("Obstacle"))
         {
             Debug.Log("Hit Asteroid");
             Destroy(gameObject);
         }
         
         Debug.Log("Hit " + other.gameObject);
     }
    }
}

