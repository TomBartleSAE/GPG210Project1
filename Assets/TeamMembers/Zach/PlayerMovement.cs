using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : NetworkBehaviour
{
    public Rigidbody rigidBody;
    private ZachsPlayerActions zachsPlayerActions;
    public Vector3 rotateVelocity;
    public float speed;

    public float forwardFloat;

    // Start is called before the first frame update
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        Debug.Log(isLocalPlayer);
        zachsPlayerActions = new ZachsPlayerActions();
        zachsPlayerActions.Enable();

        zachsPlayerActions.Main.Move.started += Movement;
        zachsPlayerActions.Main.Move.canceled += Movement;
        zachsPlayerActions.Main.Rotate.started += RotateOnPerformed;
        zachsPlayerActions.Main.Rotate.canceled += RotateOnPerformed;
    }

    public void FixedUpdate()
    {
        if (isLocalPlayer)
        {
           rigidBody.AddRelativeForce(transform.forward * speed * forwardFloat);
           rigidBody.angularVelocity = rotateVelocity;  
        }
       
    }

    void Movement(InputAction.CallbackContext obj)
    {
        //velocity = new Vector3(0, 0, speed * obj.ReadValue<float>());
        forwardFloat = obj.ReadValue<float>();
    }
   
    private void RotateOnPerformed(InputAction.CallbackContext obj)
    {
        rotateVelocity = new Vector3(0, 15 * obj.ReadValue<float>(), 0);
    }
}
