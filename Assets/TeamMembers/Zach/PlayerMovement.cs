using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            rigidBody.AddRelativeForce(new Vector3(100,0,0));
        }

        if (Keyboard.current.sKey.isPressed)
        {
            rigidBody.AddRelativeForce(new Vector3(-100,0,0));
        }

        if (Keyboard.current.aKey.isPressed)
        {
            rigidBody.AddRelativeTorque(new Vector3(0,-5,0));
        }

        if (Keyboard.current.dKey.isPressed)
        {
            rigidBody.AddRelativeTorque(new Vector3(0,5,0));
        }
    }
}
