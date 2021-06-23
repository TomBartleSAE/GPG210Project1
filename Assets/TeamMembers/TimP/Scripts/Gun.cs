using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Tim
{
    public class Gun : NetworkBehaviour
    {
        public Vector3 cPos;
        public GameObject bullet;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            cPos = transform.localPosition;
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Instantiate(bullet,cPos,transform.rotation);
            }
        }
        
    }
}
