using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayableChararacterCombat : MonoBehaviour
{
    protected abstract void Engage();
    public abstract void Disengage();
    public abstract void OnPrimaryAttack(InputAction.CallbackContext value);
}
