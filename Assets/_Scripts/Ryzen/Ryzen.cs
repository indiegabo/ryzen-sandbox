using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ryzen : Entity<RyzenCore>
{
    public static Ryzen Instance;

    // States 
    public RyzenSpawnState spawnState;
    public RyzenIdleState idleState;
    public RyzenRunningState runningState;
    public RyzenAscendingState ascendingState;

    Func<bool> InputNotZero() => () => RyzenInputHandler.Instance.currentHorizontalMovement.x != 0f;
    Func<bool> InputZero() => () => RyzenInputHandler.Instance.currentHorizontalMovement.x == 0f;

    protected override void Awake()
    {
        base.Awake();

        //Setup Player Singleton for ease of access from enemies and other scripts
        Instance = this;

        // Initiate States
        this.spawnState = new RyzenSpawnState(this.stateMachine, this);
        this.idleState = new RyzenIdleState(this.stateMachine, this);
        this.runningState = new RyzenRunningState(this.stateMachine, this);
        this.ascendingState = new RyzenAscendingState(this.stateMachine, this);

        // Idle State Transitions
        this.idleState.AddTransition(this.runningState, this.InputNotZero());

        // Running State Transitions
        this.runningState.AddTransition(this.idleState, this.InputZero());

        //Set Default State
        this.stateMachine.SetActiveState(this.spawnState);
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
    /// Set player Rigidbody.velocity.y
    /// </summary>
    /// <param name="velocityY"></param>
    public void SetVelocityY(float velocityY)
    {
        this._core.rgbd.velocity = new Vector2(this._core.rgbd.velocity.x, velocityY);
    }

    /// <summary>
    /// Flip transform localScale if true
    /// </summary>
    /// <param name="flip"></param>
    public void FlipPlayer()
    {
        this.transform.Rotate(0f, -180f, 0f);
    }
}
