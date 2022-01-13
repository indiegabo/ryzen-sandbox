using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayableChararacterCombat : MonoBehaviour
{

    // Needed Components
    protected PlayableCharacter _playableCharacter;


    // Flags
    protected bool _engagedOnAttack;

    // Logic Stuff
    protected float _engagedAt = 0;
    protected bool _attemptingToEngage = false;

    // Getters
    public bool engagedOnAttack => _engagedOnAttack;

    // Monobehaviour Cycle
    protected virtual void Awake()
    {
        this._playableCharacter = GetComponent<PlayableCharacter>();
    }

    protected virtual void Update()
    {
        this.HandleEngagement();
    }

    // Upon Certain Events
    public void InterruptAttack()
    {
        this.Disengage();
    }

    // Handling Stuff
    protected virtual void HandleEngagement()
    {
        if (this.CanEngage())
        {
            this.Engage();
        }
    }

    // Executing Stuff
    protected virtual void Engage()
    {
        this._engagedOnAttack = true;
        this._engagedAt = Time.time;
    }
    protected virtual void Disengage()
    {
        this._engagedOnAttack = false;
        this._attemptingToEngage = false;
        this._engagedAt = 0;
    }


    // Checks

    protected bool CanEngage()
    {
        return !this._playableCharacter.takingHit && !this._playableCharacter.isDead && !this._engagedOnAttack && this._playableCharacter.isGrounded && !this._playableCharacter.isDashing && this._attemptingToEngage;
    }

    // Events
    public virtual void OnPrimaryAttack(InputAction.CallbackContext value)
    {
        // Primary attack button pressed 
        if (value.started)
        {
            this._attemptingToEngage = true;
        }

        // Primary attack button Released
        if (value.canceled && this._playableCharacter.isGrounded)
        {
            this._attemptingToEngage = false;
        }
    }
}
