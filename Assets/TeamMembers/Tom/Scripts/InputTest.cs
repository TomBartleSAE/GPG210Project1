using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    private TomControls tomControls;

    // Start is called before the first frame update
    void Start()
    {
        tomControls = new TomControls();
        tomControls.Enable();

        tomControls.Main.Jump.performed += Jump;
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        print("Jump");
    }
}
