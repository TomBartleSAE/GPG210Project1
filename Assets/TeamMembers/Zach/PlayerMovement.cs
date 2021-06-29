using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
    private ZachsPlayerActions zachsPlayerActions;
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        zachsPlayerActions = new ZachsPlayerActions();
        zachsPlayerActions.Enable();
        
        zachsPlayerActions.Main.Move.started += Movement;
        //zachsPlayerActions.Main.Move.performed += ResettingMovement;
        zachsPlayerActions.Main.Rotate.started += RotateOnPerformed;
    }

   

    public void FixedUpdate()
    {
        rigidBody.velocity = velocity;
    }


    void Movement(InputAction.CallbackContext obj)
    {
        
        velocity = new Vector3(100 * obj.ReadValue<float>(), 0, 0);
        if (obj.phase == InputActionPhase.Canceled)
        {
            Debug.Log("Ending Movement");
        }
    }
    private void ResettingMovement(InputAction.CallbackContext obj)
    {
        velocity = new Vector3(0, 0, 0);
    }
    private void RotateOnPerformed(InputAction.CallbackContext obj)
    {
        //rigidBody.AddRelativeTorque(new Vector3(0,5*obj.ReadValue<float>(),0));
        transform.Rotate(new Vector3(0,15 * obj.ReadValue<float>(),0));
    }
}
