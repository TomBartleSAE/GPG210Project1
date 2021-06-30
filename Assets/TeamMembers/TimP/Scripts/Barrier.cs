using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Barrier : NetworkBehaviour
{
    public GameObject pairedBarrier;
    public float offset = 1f;
    
    public bool xTele;
    public bool zTele;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if xTele = true, then teleport code
        if (xTele == true)
        {
            //teleport along x axis
        }

        if (zTele == true)
        {
            //teleport along z axis
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Offset allows for object to teleport in front of other barrier instead of inside it
        float distance = Vector3.Distance(transform.position, pairedBarrier.transform.position) - offset;
        other.transform.position += transform.forward * distance;
    }
}
