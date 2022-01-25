using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RyzenInputHandler : MonoBehaviour
{
    public static RyzenInputHandler Instance;

    public Vector2 currentHorizontalMovement => this._currentHorizontalMovement;

    private Vector2 _currentHorizontalMovement;

    private void Awake()
    {
        Instance = this;
    }

    public void SetMovement(InputAction.CallbackContext value)
    {
        this._currentHorizontalMovement = value.ReadValue<Vector2>();
    }
}
