
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayableCharacterMovement : MonoBehaviour
{
    protected bool _grounded;
    protected bool _dashing;
    protected bool _jumping;

    public bool grounded => _grounded;
    public bool dashing => _dashing;
    public bool jumping => _jumping;

    protected virtual void Update()
    {

    }
    protected abstract void HandleGrounding();
    protected abstract void HandleJump();
    protected abstract void FaceCharacter();
    protected abstract void Move();
    public abstract void OnMovement(InputAction.CallbackContext action);
    public abstract void OnStickMovement(InputAction.CallbackContext action);
    public abstract void OnJumpAction(InputAction.CallbackContext action);
    public abstract void OnDashAction(InputAction.CallbackContext action);
}
