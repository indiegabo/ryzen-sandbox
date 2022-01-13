using UnityEngine;

public abstract class PlayableCharacter : MonoBehaviour
{
    protected Rigidbody2D _rb;
    protected IStateManager _stateManager;
    protected PlayableChararacterCombat _characterCombat;
    protected PlayableCharacterMovement _characterMovement;
    protected Unit _unit;

    protected bool _invunerable = false;

    // Getters
    public Rigidbody2D rb => this._rb;
    public bool isGrounded => this._characterMovement.grounded;
    public bool isDashing => this._characterMovement.dashing;
    public bool isDead => this._unit.dead;

    public bool takingHit => this._unit.takingHit;
    public bool invunerable => this._unit.invunerable;
    public bool engagedOnAttack => this._characterCombat.engagedOnAttack;


    // Monobehaviour Cycle
    protected void Awake()
    {
        this._rb = GetComponent<Rigidbody2D>();
        this._stateManager = GetComponent<IStateManager>();
        this._characterCombat = GetComponent<PlayableChararacterCombat>();
        this._characterMovement = GetComponent<PlayableCharacterMovement>();
        this._unit = GetComponent<Unit>();
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
