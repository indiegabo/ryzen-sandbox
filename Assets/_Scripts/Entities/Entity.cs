using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity<T> : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }
    protected T _core;

    protected virtual void Awake()
    {
        // Gets the entity core
        this._core = GetComponent<T>();

        // Initialize State Machine
        this.stateMachine = new StateMachine();
    }
}
