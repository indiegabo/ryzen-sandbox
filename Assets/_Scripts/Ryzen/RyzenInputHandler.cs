using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RyzenInputHandler : MonoBehaviour
{
    public static RyzenInputHandler Instance;

    // Logic
    private Vector2 _currentHorizontalMovement;
    private bool _jumpButtonPressed;

    // Getters
    public Vector2 currentHorizontalMovement => this._currentHorizontalMovement;
    public bool jumpButtonPressed => this._jumpButtonPressed;

    private void Awake()
    {
        Instance = this;
    }

    public void SetMovement(InputAction.CallbackContext value)
    {
        this._currentHorizontalMovement = value.ReadValue<Vector2>();
    }

    public void JumpAction(InputAction.CallbackContext action)
    {
        // Jump Button Pressed
        if (action.started)
        {
            this._jumpButtonPressed = true;
        }

        // Jump Button Released
        if (action.canceled)
        {
            this._jumpButtonPressed = false;
        }
    }
}
