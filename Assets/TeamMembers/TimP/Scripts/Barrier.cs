using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Barrier : NetworkBehaviour
{
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
}
