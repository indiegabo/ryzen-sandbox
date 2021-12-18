using UnityEngine;

public class PlayableCharacterController : MonoBehaviour
{
    protected IStateManager _stateManager;
    protected PlayableChararacterCombat _characterCombat;

    protected bool _grounded;
    protected bool _engagedOnAttack;

    public bool grounded
    {
        get { return this._grounded; }
        set { this._grounded = value; }
    }

    public bool engagedOnAttack
    {
        get { return this._engagedOnAttack; }
        set { this._engagedOnAttack = value; }
    }

    // Monobehaviour Cycle
    private void Awake()
    {
        this._stateManager = GetComponent<IStateManager>();
        this._characterCombat = GetComponent<PlayableChararacterCombat>();
    }
    private void OnEnable()
    {
        PlayableCharacterEventManager.OnJumpStarted += JumpStarted;
    }

    private void OnDisable()
    {
        PlayableCharacterEventManager.OnJumpStarted -= JumpStarted;
    }

    // Executing tasks
    public void JumpStarted(GameObject jumpingChararacter)
    {
        Debug.Log(jumpingChararacter.name);
        this._characterCombat.Disengage();
    }

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
