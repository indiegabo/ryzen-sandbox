using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RyzenInputHandler : MonoBehaviour
{
    public static RyzenInputHandler Instance;

    public Vector2 currentInput;

    private void Awake()
    {
        Instance = this;
    }

    public void SetInput(InputAction.CallbackContext value)
    {
        currentInput = value.ReadValue<Vector2>();
    }
}
