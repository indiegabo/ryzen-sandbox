using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenEntity : MonoBehaviour
{
    public static RyzenEntity Instance;

    private StateMachine _stateMachine;
    private RyzenCore _core;
    private IdleState _idleState;
    private WalkState _walkState;
	
	public StateMachine stateMachine => _stateMachine;
	public IdleState idleState => _idleState;
    public WalkState walkState => _walkState;

    Func<bool> InputNotZero() => () => RyzenInputHandler.Instance.currentInput.x != 0f;
    Func<bool> InputZero() => () => RyzenInputHandler.Instance.currentInput.x == 0f;

    private void Awake()
    {
        //Setup Player Singleton for ease of access from enemies and other scripts
        Instance = this;

        _core = GetComponent<RyzenCore>();

        //Initialize State Machine
        _stateMachine = new StateMachine();
        _idleState = new IdleState(_stateMachine, this, _core);
        _walkState = new WalkState(_stateMachine, this, _core);

        //Setup State Transitions
        _stateMachine.AddTransition(_idleState, _walkState, InputNotZero());
        _stateMachine.AddTransition(_walkState, _idleState, InputZero());

        //Set Default State
        _stateMachine.SetState(_idleState);
    }

    private void Update()
    {
        //Tick the state machine "Tick" method every frame
        _stateMachine.Tick();
    }
	
	private void FixedUpdate()
	{
        //Tick the state machine "FixedTick" method every physics update
        _stateMachine.FixedTick();
	}

    /// <summary>
    /// Set player Rigidbody.velocity.x
    /// </summary>
    /// <param name="velocityX"></param>
    public void SetVelocityX(float velocityX)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, GetComponent<Rigidbody2D>().velocity.y);
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
