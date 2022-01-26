using System;
using System.Collections.Generic;

public class StateTransition
{
    public static List<StateTransition> emptyTransitions = new List<StateTransition>(0);
    public Func<bool> condition { get; }
    public State to { get; }

    public StateTransition(State to, Func<bool> condition)
    {
        this.to = to;
        this.condition = condition;
    }
}
