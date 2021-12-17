using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, ICharacterController
{

    // States
    private ICharacterState _characterState;
    private IChararacterCombat _characterCombat;
    private bool _grounded;
    private bool _engagedOnAttack;

    private void OnEnable()
    {
        CharacterEventManager.OnJumpStart += JumpStarted;
    }

    private void OnDisable()
    {
        CharacterEventManager.OnJumpStart -= JumpStarted;
    }

    private void Awake()
    {
        this._characterState = GetComponent<ICharacterState>();
        this._characterCombat = GetComponent<IChararacterCombat>();
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
