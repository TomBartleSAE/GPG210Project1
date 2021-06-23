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
        zachsPlayerActions = new ZachsPlayerActions();
        zachsPlayerActions.Enable();
        
        zachsPlayerActions.Main.Move.performed += Movement;
        zachsPlayerActions.Main.Rotate.performed += RotateOnPerformed;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    void Movement(InputAction.CallbackContext obj)
    {
        Debug.Log("Moving");
        rigidBody.AddRelativeForce(new Vector3(100 * obj.ReadValue<float>(),0,0));
    }

    private void RotateOnPerformed(InputAction.CallbackContext obj)
    {
        rigidBody.AddRelativeTorque(new Vector3(0,5*obj.ReadValue<float>(),0));
    }
}
