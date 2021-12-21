using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayableChararacterCombat : MonoBehaviour
{

    // Needed Components
    protected PlayableCharacter _character;


    // Flags
    protected bool _engagedOnAttack;
    protected float _engagedAt = 0;
    protected bool _attemptingToEngage = false;

    // Getters
    public bool engagedOnAttack => _engagedOnAttack;

    // Monobehaviour Cycle
    protected virtual void Awake()
    {
        this._character = GetComponent<PlayableCharacter>();
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

    private bool CanEngage()
    {
        return !this._engagedOnAttack && this._character.isGrounded() && !this._character.isDashing() && this._attemptingToEngage;
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
        if (value.canceled && this._character.isGrounded())
        {
            this._attemptingToEngage = false;
        }
    }
}
