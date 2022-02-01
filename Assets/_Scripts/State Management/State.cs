using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{

    // Transitions
    private List<StateTransition> _transitions = new List<StateTransition>();


    /// <summary>
    /// Returns the state transitions list
    /// </summary>  
    public List<StateTransition> GetTransitions()
    {
        return this._transitions;
    }

    /// <summary>
    /// Adds a Transition to the state
    /// </summary>
    /// <param name="to"> The state to be transitioned to </param>
    /// <param name="predicate"> The predicate function wich evaluates the condition </param>
    public void AddTransition(Func<State> To, Func<bool> Condition)
    {
        this._transitions.Add(new StateTransition(To, Condition));
    }

    /// <summary>
    /// Clears all transitions for that state
    /// </summary>
    public void ClearTransitions()
    {
        this._transitions.Clear();
    }

    public abstract void Tick();
    public abstract void FixedTick();
    public abstract void OnEnter();
    public abstract void OnExit();
}
