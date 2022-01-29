using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity<T> : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }
    protected T _core;

    public T core => this._core;
    protected virtual void Awake()
    {
        // Gets the entity core
        this._core = GetComponent<T>();

        // Initialize State Machine
        this.stateMachine = new StateMachine();
    }

    /// <summary>
    /// Changes the Entity current state
    /// </summary>
    /// <param name="state"> The State wich should now be active </param>
    public virtual void ChangeState(State state)
    {
        this.stateMachine.SetActiveState(state);
    }
}
