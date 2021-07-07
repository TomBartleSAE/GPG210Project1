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
        public NetworkIdentity ownerIdentity;
    // Start is called before the first frame update
     void Start()
     {
         rb = GetComponent<Rigidbody>();
         rb.AddRelativeForce(new Vector3(0,0,5), ForceMode.Impulse);
     }
//check for local player, bigger bullets and shoot less often
    // Update is called once per frame
    private void FixedUpdate()
    {
        dTimer = dTimer - Time.deltaTime;
        if (dTimer <=0f)
        {
            Destroy(gameObject);
        }
    }

    /*private void OnCollisionEnter(Collision other)
     {
         if (other.gameObject.CompareTag("Obstacle"))
         {
             Debug.Log("Hit Asteroid");
             Destroy(gameObject);
         }
         
         Debug.Log("Hit " + other.gameObject);
     }
     */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hit Asteroid");
            Destroy(gameObject);
            if (other.GetComponent<Health>())
            {
                other.GetComponent<Health>().CallDamageEvent(1);
            }
        }

        if (other.gameObject.GetComponent<NetworkIdentity>() != ownerIdentity && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
        }
        
        Debug.Log("Hit " + other.gameObject);
    }
    }
}

//networktransform