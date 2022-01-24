using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenEntity : MonoBehaviour
{
    public static RyzenEntity Instance;

    public StateMachine StateMachine { get; private set; }
    public IdleState IdleState { get; private set; }
    public WalkState WalkState { get; private set; }

    private RyzenCore _core;

    Func<bool> InputNotZero() => () => RyzenInputHandler.Instance.currentInput.x != 0f;
    Func<bool> InputZero() => () => RyzenInputHandler.Instance.currentInput.x == 0f;

    private void Awake()
    {
        //Setup Player Singleton for ease of access from enemies and other scripts
        Instance = this;

        _core = GetComponent<RyzenCore>();

        //Initialize State Machine
        StateMachine = new StateMachine();
        IdleState = new IdleState(StateMachine, this, _core);
        WalkState = new WalkState(StateMachine, this, _core);

        //Setup State Transitions
        StateMachine.AddTransition(IdleState, WalkState, InputNotZero());
        StateMachine.AddTransition(WalkState, IdleState, InputZero());

        //Set Default State
        StateMachine.SetState(IdleState);
    }

    private void Update()
    {
        //Tick the state machine "Tick" method every frame
        StateMachine.Tick();
    }
	
	private void FixedUpdate()
	{
        //Tick the state machine "FixedTick" method every physics update
        StateMachine.FixedTick();
	}

    /// <summary>
    /// Set player Rigidbody.velocity.x
    /// </summary>
    /// <param name="velocityX"></param>
    public void SetVelocityX(float velocityX)
    {
        _core.rgbd.velocity = new Vector2(velocityX, _core.rgbd.velocity.y);
    }

    /// <summary>
    /// Flip transform localScale if true
    /// </summary>
    /// <param name="flip"></param>
    public void FlipPlayer(bool flip)
    {
        transform.localScale = new Vector3(flip ? -1f : 1f, 1f, 1f);
    }
}
