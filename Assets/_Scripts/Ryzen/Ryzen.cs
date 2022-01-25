using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ryzen : MonoBehaviour
{

    public static Ryzen Instance;

    public StateMachine StateMachine { get; private set; }
    private RyzenCore _ryzenCore;

    Func<bool> InputNotZero() => () => RyzenInputHandler.Instance.currentHorizontalMovement.x != 0f;
    Func<bool> InputZero() => () => RyzenInputHandler.Instance.currentHorizontalMovement.x == 0f;

    private void Awake()
    {
        //Setup Player Singleton for ease of access from enemies and other scripts
        Instance = this;

        this._ryzenCore = GetComponent<RyzenCore>();

        //Initialize State Machine
        this.StateMachine = new StateMachine();
    }

    private void Update()
    {
        //Tick the state machine "Tick" method every frame
        this.StateMachine.Tick();
    }

    private void FixedUpdate()
    {
        //Tick the state machine "FixedTick" method every physics update
        this.StateMachine.FixedTick();
    }

    /// <summary>
    /// Set player Rigidbody.velocity.x
    /// </summary>
    /// <param name="velocityX"></param>
    public void SetVelocityX(float velocityX)
    {
        this._ryzenCore.rgbd.velocity = new Vector2(velocityX, this._ryzenCore.rgbd.velocity.y);
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
