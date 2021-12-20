using UnityEngine;

public abstract class PlayableCharacter : MonoBehaviour
{
    protected IStateManager _stateManager;
    public PlayableChararacterCombat _characterCombat;
    public PlayableCharacterMovement _characterMovement;

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

    public bool isEngagedOnAttack()
    {
        return this._characterCombat.engagedOnAttack;
    }

    private void InterruptAttack()
    {
        this._characterCombat.Disengage();
    }

    // Monobehaviour Cycle
    private void Awake()
    {
        this._stateManager = GetComponent<IStateManager>();
        this._characterCombat = GetComponent<PlayableChararacterCombat>();
        this._characterMovement = GetComponent<PlayableCharacterMovement>();
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
