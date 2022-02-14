using System;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition
{
    /// <summary>
    /// The condition wich should be stablished in order to the current state transitate into
    /// the "To" State property
    /// </summary>
    public Func<bool> Condition { get; }

    /// <summary>
    /// The State wich should be transitioned to
    /// </summary>
    public Func<State> To { get; }

    public StateTransition(Func<State> To, Func<bool> Condition)
    {
        this.To = To;
        this.Condition = Condition;
    }
}
