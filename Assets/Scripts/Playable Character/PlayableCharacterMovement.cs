
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayableCharacterMovement : MonoBehaviour
{
    protected abstract void HandleGrounding();
    protected abstract void HandleJump();
    protected abstract void FaceCharacter();
    protected abstract void Move();
    public abstract void OnMovement(InputAction.CallbackContext value);
    public abstract void OnStickMovement(InputAction.CallbackContext value);
    public abstract void OnJump(InputAction.CallbackContext value);
}
