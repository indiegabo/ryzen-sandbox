using UnityEngine;

public class WalkState : IState
{
	private readonly StateMachine _stateMachine;
    private readonly RyzenEntity _playerEntity;
    private readonly RyzenCore _core;

    public WalkState(StateMachine stateMachine, RyzenEntity playerEntity, RyzenCore core)
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
        _playerEntity.SetVelocityX(_core.inputHandler.currentInput.x * 100f * Time.deltaTime);
        _playerEntity.FlipPlayer(_core.inputHandler.currentInput.x == -1f ? true : false);
    }

    /// <summary>
    /// Ticked when the state machine enter this state
    /// </summary>
    public void OnEnter()
    {
        _core.anim.SetBool("Running", true);
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public void OnExit()
    {
        _core.anim.SetBool("Running", false);
    }
}
