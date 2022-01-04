using UnityEngine;

public abstract class PlayableCharacter : MonoBehaviour, IDamageable
{
    protected IStateManager _stateManager;
    protected PlayableChararacterCombat _characterCombat;
    protected PlayableCharacterMovement _characterMovement;


    // Monobehaviour Cycle
    protected void Awake()
    {
        this._stateManager = GetComponent<IStateManager>();
        this._characterCombat = GetComponent<PlayableChararacterCombat>();
        this._characterMovement = GetComponent<PlayableCharacterMovement>();
    }

    // State Check
    public bool isEngagedOnAttack()
    {
        return this._characterCombat.engagedOnAttack;
    }

    public bool isGrounded()
    {
        return this._characterMovement.grounded;
    }

    public bool isDashing()
    {
        return this._characterMovement.dashing;
    }

    // Upon Certain Events
    public void OnJumpStart()
    {
        this.InterruptAttack();
    }

    public void OnDashStart()
    {
        this.InterruptAttack();
    }

    public void OnTakingDamage(float damageAmount)
    {

    }

    // Actions
    protected void InterruptAttack()
    {
        this._characterCombat.InterruptAttack();
    }

    public void TakeDamage(float amount)
    {
        Debug.Log(amount);
    }


    // Executing tasks

    // States
    public void ChangeState(string stateName)
    {
        this._stateManager.ChangeState(stateName);
    }

    public float CurrentAnimationDuration()
    {
        return this._stateManager.CurrentAnimationDuration();
    }

}
