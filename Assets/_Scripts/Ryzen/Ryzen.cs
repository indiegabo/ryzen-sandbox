using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ryzen : Entity<RyzenCore>
{
    public static Ryzen Instance;

    public RyzenIdleState _idleState;
    public RyzenRunningState _runningState;

    Func<bool> InputNotZero() => () => RyzenInputHandler.Instance.currentHorizontalMovement.x != 0f;
    Func<bool> InputZero() => () => RyzenInputHandler.Instance.currentHorizontalMovement.x == 0f;

    protected override void Awake()
    {
        base.Awake();

        //Setup Player Singleton for ease of access from enemies and other scripts
        Instance = this;

        // Initiate States 
        this._idleState = new RyzenIdleState(this.stateMachine, this, _core);
        this._runningState = new RyzenRunningState(this.stateMachine, this, _core);

        //Setup State Transitions
        this.stateMachine.AddTransition(this._idleState, this._runningState, InputNotZero());
        this.stateMachine.AddTransition(this._runningState, this._idleState, InputZero());


        //Set Default State
        this.stateMachine.SetState(this._idleState);
    }

    private void Update()
    {
        //Tick the state machine "Tick" method every frame
        this.stateMachine.Tick();
    }

    private void FixedUpdate()
    {
        //Tick the state machine "FixedTick" method every physics update
        this.stateMachine.FixedTick();
    }

    /// <summary>
    /// Set player Rigidbody.velocity.x
    /// </summary>
    /// <param name="velocityX"></param>
    public void SetVelocityX(float velocityX)
    {
        this._core.rgbd.velocity = new Vector2(velocityX, this._core.rgbd.velocity.y);
    }

    /// <summary>
    /// Flip transform localScale if true
    /// </summary>
    /// <param name="flip"></param>
    public void FlipPlayer(bool flip)
    {
        if (flip)
            this.transform.Rotate(0f, -180f, 0f);
    }
}
