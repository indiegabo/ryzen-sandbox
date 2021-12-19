
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayableCharacterMovement : MonoBehaviour
{
    protected abstract void HandleGrounding();
    protected abstract void HandleJump();
    protected abstract void FaceCharacter();
    protected abstract void Move();
    public abstract void OnMovement(InputAction.CallbackContext action);
    public abstract void OnStickMovement(InputAction.CallbackContext action);
    public abstract void OnJumpAction(InputAction.CallbackContext action);
    public abstract void OnDashAction(InputAction.CallbackContext action);
}
