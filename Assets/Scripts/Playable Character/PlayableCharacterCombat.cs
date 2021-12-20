using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayableChararacterCombat : MonoBehaviour
{
    protected bool _engagedOnAttack;
    public bool engagedOnAttack => _engagedOnAttack;
    protected abstract void Engage();
    public abstract void Disengage();
    public abstract void OnPrimaryAttack(InputAction.CallbackContext value);
}
