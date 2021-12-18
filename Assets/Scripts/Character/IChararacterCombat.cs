using UnityEngine.InputSystem;

public interface IChararacterCombat
{
    void AttackDisengage();
    void OnPrimaryAttack(InputAction.CallbackContext value);
}
