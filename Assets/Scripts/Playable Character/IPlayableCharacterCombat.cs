using UnityEngine.InputSystem;

public interface IPlayableChararacterCombat
{
    void AttackDisengage();
    void OnPrimaryAttack(InputAction.CallbackContext value);
}
