using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenUnit : Unit, IDamageable
{
    [SerializeField] protected float _hitAnimationTime = 0.25f;
    [SerializeField] protected float _defaultKnockBackForce = 0.25f;
    protected PlayableCharacter _playableCharacter;
    protected float _currentKnockBackForce = 0f;

    protected void Awake()
    {
        this._playableCharacter = GetComponent<PlayableCharacter>();
    }

    protected void FixedUpdate()
    {
        if (this._takingHit)
        {
            Debug.Log(this._currentKnockBackForce);
            this._playableCharacter.rb.AddForce(Vector2.left * this._currentKnockBackForce);
        }
    }

    public void TakeDamage(float amount, float? knockBackForce)
    {
        if (this._invunerable)
            return;

        this.LoseHP(amount);

        if (this.dead)
        {
            this.Die();
        }
        else
        {
            this._currentKnockBackForce = (knockBackForce.HasValue) ? knockBackForce.Value : this._defaultKnockBackForce;
            this.TakeHit();
        }
    }

    public void Die()
    {
        this._playableCharacter.ChangeState(RyzenState.Death.ToString());
    }

    public void TakeHit()
    {
        this._invunerable = true;
        this._takingHit = true;
        this._playableCharacter.ChangeState(RyzenState.Hit.ToString());
        Invoke("DoneTakingHit", this._hitAnimationTime);
    }

    // Invokables
    protected void DoneTakingHit()
    {
        this._invunerable = false;
        this._takingHit = false;
        this._currentKnockBackForce = 0f;
    }
}
