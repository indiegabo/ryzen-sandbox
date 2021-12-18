
using UnityEngine.InputSystem;

public interface ICharacterMovement
{
    void OnMovement(InputAction.CallbackContext value);
    void OnStickMovement(InputAction.CallbackContext value);
    void OnJump(InputAction.CallbackContext value);
}
