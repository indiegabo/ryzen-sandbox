
using UnityEngine;

public class StateMachine
{
    protected State _activeState;

    /// <summary>
    /// Must be executed every Entity's monobehaviour update 
    /// </summary>
    public void Tick()
    {
        this.EvaluateNextState();
        _activeState?.Tick();
    }

    /// <summary>
    /// Must be executed every Entity's monobehaviour fixedUpdate
    /// </summary>
    public void FixedTick()
    {
        this.EvaluateNextState();
        _activeState?.FixedTick();
    }

    /// <summary>
    /// Evaluates if the state should be transitioned. 
    /// If so, executes the transitation.
    /// </summary>
    private void EvaluateNextState()
    {
        State state = GetNextState();
        if (state != null)
            this.SetActiveState(state);
    }

    /// <summary>
    /// Defines a given state as active
    /// </summary>
    /// <param name="state"> The state to be set as active </param>
    public void SetActiveState(State state)
    {
        if (state == _activeState)
            return;

        _activeState?.OnExit();

        _activeState = state;

        _activeState.OnEnter();
    }

    /// <summary>
    /// Returns a state that has been evaluated as true on it's transition's condition
    /// </summary>
    private State GetNextState()
    {
        foreach (StateTransition transition in this._activeState?.GetTransitions())
        {
            if (transition.Condition())
                return transition.To();
        }

        return null;
    }
}
