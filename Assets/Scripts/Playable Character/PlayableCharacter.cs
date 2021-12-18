using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : MonoBehaviour, IPlayableCharacterController
{

    // States
    private IPlayableCharacterState _characterState;
    private IPlayableChararacterCombat _characterCombat;
    private bool _grounded;
    private bool _engagedOnAttack;

    private void OnEnable()
    {
        PlayableCharacterEventManager.OnJumpStarted += JumpStarted;
    }

    private void OnDisable()
    {
        PlayableCharacterEventManager.OnJumpStarted -= JumpStarted;
    }

    private void Awake()
    {
        this._characterState = GetComponent<IPlayableCharacterState>();
        this._characterCombat = GetComponent<IPlayableChararacterCombat>();
    }

    public void ChangeState(string stateName)
    {
        this._characterState.ChangeState(stateName);
    }

    public float CurrentAnimationDuration()
    {
        return this._characterState.CurrentAnimationDuration();
    }

    public void JumpStarted()
    {
        this._characterCombat.AttackDisengage();
    }

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
}
