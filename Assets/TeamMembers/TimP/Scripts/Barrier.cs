using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Barrier : NetworkBehaviour
{
    public GameObject pairedBarrier;
    public float offset = 1f;

    private void OnTriggerEnter(Collider other)
    {
        float dotProduct = Vector3.Dot(other.GetComponent<Rigidbody>().velocity.normalized, transform.forward);

        if (dotProduct < 0)
        {
            // Offset allows for object to teleport in front of other barrier instead of inside it
            float distance = Vector3.Distance(transform.position, pairedBarrier.transform.position) - offset;
            other.transform.position += transform.forward * distance;
        }
    }
}
