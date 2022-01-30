using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenStateLoadingShoot : RyzenStateGrounded
{
    private const float MIN_EMPOWERING_SCALE = 0f;
    private const float MAX_EMPOWERING_SCALE = 1f;

    Func<State> IdleState() => () => this._ryzen.idleState;
    Func<bool> ButtonRelesead() => () => !this._ryzen.core.inputHandler.attemptingToAttack;

    // Config Properties
    private bool _currentEmpoweringMaxReached = false;
    private float _engagedAt = 0;

    public RyzenStateLoadingShoot(Ryzen ryzen) : base(ryzen)
    {
        // Register Default Transitions
        this.AddTransition(this.IdleState(), this.ButtonRelesead());
    }

    /// <summary>
    /// Ticked on every frame
    /// </summary>
    public override void Tick()
    {
        base.Tick();
        this.HandleEmpoweringScaling();
    }

    /// <summary>
    /// Ticked on every physics update
    /// </summary>
    public override void FixedTick()
    {
        base.FixedTick();
    }

    /// <summary>
    /// Ticked when the state machine enter this state
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        this._ryzen.core.anim.SetBool(RyzenStateEnum.LoadingShoot, true);
        this._engagedAt = Time.time;
        CanvasController.Instance.EnableLoadingShootSlider();
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        this._currentEmpoweringMaxReached = false;
        this._ryzen.core.anim.SetBool(RyzenStateEnum.LoadingShoot, false);
        CanvasController.Instance.DisableLoadingShootSlider();
    }

    private void HandleEmpoweringScaling()
    {

        float min = this._engagedAt + this._ryzen.core.data.loadingShootTime;
        float max = this._engagedAt + this._ryzen.core.data.loadingShootTime + this._ryzen.core.data.empoweringShootMin;

        // Reached maximum empowering 
        if (Time.time >= max && !this._currentEmpoweringMaxReached)
        {
            this._currentEmpoweringMaxReached = true;
        }

        if (Time.time < min || Time.time > max)
            return;


        float elapsedTime = Time.time - min;
        float scale = Calc.convertScale(elapsedTime, this._ryzen.core.data.empoweringShootMin, MIN_EMPOWERING_SCALE, MAX_EMPOWERING_SCALE, 0.98f);
        CanvasController.Instance.SetLoadingShootSlider(scale);
    }
}
