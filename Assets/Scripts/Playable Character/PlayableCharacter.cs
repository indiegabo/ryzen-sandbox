using UnityEngine;

public class PlayableCharacter : MonoBehaviour
{
    protected IStateManager _stateManager;
    protected PlayableChararacterCombat _characterCombat;
    protected PlayableCharacterMovement _characterMovement;

    protected bool _grounded;
    protected bool _engagedOnAttack;
    protected bool _dashing;
    protected bool _jumping;

    public bool grounded
    {
        get { return this._grounded; }
        set { this._grounded = value; }
    }

    public bool engagedOnAttack
    {
        get { return this._engagedOnAttack; }
        set
        {
            this._engagedOnAttack = value;
            if (this.engagedOnAttack)
            {
                this._dashing = false;
            }
        }
    }

    public bool dashing
    {
        get { return this._dashing; }
        set
        {
            this._dashing = value;
            if (this._dashing)
            {
                this._characterCombat.Disengage();
            }
        }
    }
    public bool jumping
    {
        get { return this._jumping; }
        set
        {
            this._jumping = value;
            if (this._jumping)
            {
                this._characterCombat.Disengage();
            }
        }
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
