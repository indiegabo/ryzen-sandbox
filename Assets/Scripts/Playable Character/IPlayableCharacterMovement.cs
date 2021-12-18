
using UnityEngine.InputSystem;

public interface IPlayableCharacterMovement
{
    void OnMovement(InputAction.CallbackContext value);
    void OnStickMovement(InputAction.CallbackContext value);
    void OnJump(InputAction.CallbackContext value);
}
