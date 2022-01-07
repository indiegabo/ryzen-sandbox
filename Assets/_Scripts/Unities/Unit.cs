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

    // Logic stuff 
    public bool dead => this._currentHP <= 0;

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
