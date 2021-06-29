using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
    private ZachsPlayerActions zachsPlayerActions;

    // Start is called before the first frame update
    void Start()
    {
        /*zachsPlayerActions = new ZachsPlayerActions();
        zachsPlayerActions.Enable();
        
        zachsPlayerActions.Main.Move.performed += Movement;
        zachsPlayerActions.Main.Rotate.performed += RotateOnPerformed;*/
    }

    public void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            rigidBody.AddRelativeForce(new Vector3(40,0,0));
        }
        if (Keyboard.current.sKey.isPressed)
        {
            rigidBody.AddRelativeForce(new Vector3(-40,0,0));
        }
        if (Keyboard.current.aKey.isPressed)
        {
            transform.Rotate(new Vector3(0,-5,0));
        }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.Rotate(new Vector3(0,5,0));
        }
    }


    void Movement(InputAction.CallbackContext obj)
    {
        Debug.Log("Moving");
        rigidBody.AddRelativeForce(new Vector3(100 * obj.ReadValue<float>(),0,0));
    }

    private void RotateOnPerformed(InputAction.CallbackContext obj)
    {
        //rigidBody.AddRelativeTorque(new Vector3(0,5*obj.ReadValue<float>(),0));
        transform.Rotate(new Vector3(0,15 * obj.ReadValue<float>(),0));
    }
}
