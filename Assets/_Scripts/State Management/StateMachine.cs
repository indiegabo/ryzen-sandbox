
using UnityEngine;

public class StateMachine
{
    /// <summary>
    /// This is the current active state for the this State Machine
    /// </summary>
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
    /// Defines a given state as active
    /// </summary>
    /// <param name="state"> The state to be set as active </param>
    public void SetActiveState(State state)
    {
        if (state == _activeState) return; // Should not change 

        _activeState?.OnExit(); // Exiting current state

        _activeState = state; // Changing current state

        _activeState.OnEnter(); // Initializing new state
    }

    /// <summary>
    /// Evaluates if the state should be transitioned. 
    /// If so, executes the transitation.
    /// </summary>
    private void EvaluateNextState()
    {
        State state = GetNextState();
        if (state != null) this.SetActiveState(state);
    }

    /// <summary>
    /// Returns a state that has been evaluated as true on it's transition's condition
    /// </summary>
    private State GetNextState()
    {
        foreach (StateTransition transition in this._activeState?.transitions)
        {
            if (transition.Condition()) return transition.To();
        }

        return null;
    }
}
