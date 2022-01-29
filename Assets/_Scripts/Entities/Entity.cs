using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity<T> : MonoBehaviour where T : EntityCore
{
    public StateMachine stateMachine { get; private set; }
    protected T _core;

    public T core => this._core;

    public bool currentAnimationEnded => this.core.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1;
    protected virtual void Awake()
    {
        // Gets the entity core
        this._core = GetComponent<T>();

        // Initialize State Machine
        this.stateMachine = new StateMachine();
    }

    /// <summary>
    /// Changes Entity active state
    /// </summary>
    /// <param name="state"></param>//
    public virtual void ChangeState(State state)
    {
        this.stateMachine.SetActiveState(state);
    }
}
