using UnityEngine;

public class IdleState : IState
{
	private readonly StateMachine _stateMachine;
    private readonly RyzenEntity _playerEntity;
    private readonly RyzenCore _core;

    public IdleState(StateMachine stateMachine, RyzenEntity playerEntity, RyzenCore core)
    {
		_stateMachine = stateMachine;
        _playerEntity = playerEntity;
        _core = core;
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

    }

    /// <summary>
    /// Ticked when the state machine enter this state
    /// </summary>
    public void OnEnter()
    {
        _core.anim.SetBool("Idle", true);
        _playerEntity.SetVelocityX(0f);
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public void OnExit()
    {
        _core.anim.SetBool("Idle", false);
    }
}
