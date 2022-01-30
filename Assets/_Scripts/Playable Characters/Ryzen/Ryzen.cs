using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ryzen : Entity<RyzenCore>
{
    public static Ryzen Instance;


    private bool _dashEnabled = true;

    // States 
    public RyzenStateSpawn spawnState { get; private set; }
    public RyzenStateIdle idleState { get; private set; }
    public RyzenStateRunning runningState { get; private set; }
    public RyzenStateDashing dashingState { get; private set; }
    public RyzenStateAscending ascendingState { get; private set; }
    public RyzenStateDescending descendingState { get; private set; }
    public RyzenStateLoadingShoot loadingShootState { get; private set; }

    // Logic
    public bool grounded => Physics2D.OverlapCircle(this.core.feet.transform.position, this.core.data.groundCheckRadius, this.core.data.whatIsGround);
    public bool dashEnabled => this._dashEnabled;


    // Monobehaviour Cycle
    protected override void Awake()
    {
        base.Awake();

        //Setup Player Singleton for ease of access from enemies and other scripts
        Instance = this;

        // Initiate States
        this.StartGroundedStates();
        this.StartOnAirStates();

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
        this.EvaluateFlip();
    }

    // Physics entity Logic

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
    /// Evaluates if Ryzen should be flipped
    /// </summary>
    public void EvaluateFlip()
    {
        if (this.core.rgbd.velocity.x > 0 && !this.core.facingRight
        || this.core.rgbd.velocity.x < 0 && this.core.facingRight)
        {
            this.core.facingRight = !this.core.facingRight;
            this.transform.Rotate(0f, -180f, 0f);
        }
    }

    /// <summary>
    /// Start Grounded States
    /// </summary>
    private void StartGroundedStates()
    {
        this.spawnState = new RyzenStateSpawn(this);
        this.idleState = new RyzenStateIdle(this);
        this.runningState = new RyzenStateRunning(this);
        this.dashingState = new RyzenStateDashing(this);
        this.loadingShootState = new RyzenStateLoadingShoot(this);
    }

    /// <summary>
    /// Start On Air States
    /// </summary>
    private void StartOnAirStates()
    {
        this.ascendingState = new RyzenStateAscending(this);
        this.descendingState = new RyzenStateDescending(this);
    }


    public void JustDashed()
    {
        StartCoroutine(this.DashDelay());
    }

    private IEnumerator DashDelay()
    {
        this._dashEnabled = false;
        yield return new WaitForSeconds(this.core.data.timeBetweenDashes);
        this._dashEnabled = true;
    }

    public void PlayEmpoweredAffordance()
    {
        Instantiate(this.core.empoweredAffordanceObject, this.core.empoweredAffordancePoint.position, this.core.empoweredAffordancePoint.rotation);
    }
}
