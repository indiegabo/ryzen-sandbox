
using UnityEngine;

public class RyzenRunningState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly Ryzen _ryzen;
    private readonly RyzenCore _core;

    public RyzenRunningState(StateMachine stateMachine, Ryzen ryzen, RyzenCore core)
    {
        this._stateMachine = stateMachine;
        this._ryzen = ryzen;
        this._core = core;
    }

    /// <summary>
    /// Ticked on every frame
    /// </summary>
    public void Tick()
    {

    }

    /// <summary>
    /// Ticked on every physics update
    /// </summary>
    public void FixedTick()
    {
        // _playerEntity.SetVelocityX(_core.inputHandler.currentInput.x * 100f * Time.deltaTime);
        // _playerEntity.FlipPlayer(_core.inputHandler.currentInput.x == -1f ? true : false);
    }

    /// <summary>
    /// Ticked when the state machine enter this state
    /// </summary>
    public void OnEnter()
    {
        this._core.anim.SetBool(RyzenState.Running, true);
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public void OnExit()
    {
        this._core.anim.SetBool(RyzenState.Running, false);
    }
}
