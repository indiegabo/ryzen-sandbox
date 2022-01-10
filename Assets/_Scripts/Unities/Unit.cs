using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Config
    [Header("Unit Health")]
    [SerializeField] protected float _totalHP;

    // Config non parameter
    protected float _currentHP;
    protected bool _invunerable = false;
    protected bool _takingHit = false;

    // Logic stuff 
    public bool dead => this._currentHP <= 0;
    public bool takingHit => this._takingHit;
    public bool invunerable => this._invunerable;

    // MonoBehaviour Cycle
    protected virtual void Start()
    {
        this._currentHP = this._totalHP;
    }


    public virtual void LoseHP(float amount)
    {
        this._currentHP -= amount;
    }

    public virtual void GainHP(float amount)
    {
        if (this._currentHP + amount >= this._totalHP)
        {
            this._currentHP = this._totalHP;
        }
        else
        {
            this._currentHP += amount;
        }
    }
}
