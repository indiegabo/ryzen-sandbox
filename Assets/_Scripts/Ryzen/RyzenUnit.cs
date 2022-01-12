using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenUnit : Unit, IDamageable
{
    [Header("Animation")]
    [SerializeField] [Range(0.5f, 1f)] protected float _hitAnimationTime = 0.25f;

    [Header("Knockback")]
    [SerializeField] [Range(0.1f, 200f)] protected float _defaultKnockBackForce = 0.25f;

    protected PlayableCharacter _playableCharacter;
    protected float _currentKnockBackForce = 0f;
    protected GameObject _currentAggressor = null;

    protected override void Awake()
    {
        base.Awake();
        this._playableCharacter = GetComponent<PlayableCharacter>();
    }

    protected void FixedUpdate()
    {
        if (this._takingHit)
        {
            float sign = Mathf.Sign(this.transform.position.x - this._currentAggressor.transform.position.x);
            if (sign >= 0)
            {
                this._playableCharacter.rb.AddForce(Vector2.right * this._currentKnockBackForce);

            }
            else
            {

                this._playableCharacter.rb.AddForce(Vector2.left * this._currentKnockBackForce);
            }
        }
    }

    public void TakeDamage(float amount, GameObject aggressor, float? knockBackForce)
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
            this.TakeHit(aggressor);
        }
    }

    public void Die()
    {
        this._playableCharacter.ChangeState(RyzenState.Death.ToString());
    }

    public void TakeHit(GameObject aggressor)
    {
        this._takingHit = true;
        this._currentAggressor = aggressor;
        this._playableCharacter.ChangeState(RyzenState.Hit.ToString());
        this.StartInvulnerability();
        Invoke("DoneTakingHit", this._hitAnimationTime);
    }
    private void StartInvulnerability()
    {
        this._invunerable = true;
    }

    // Invokables
    protected void DoneTakingHit()
    {
        this._takingHit = false;
        this._currentAggressor = null;
        this._playableCharacter.rb.velocity = new Vector2(0, 0);
        this._currentKnockBackForce = 0f;
    }
    protected void DoneBeingInvulnerable()
    {
        this._invunerable = false;
    }

    private IEnumerator InvulnerabilityEffect()
    {
        yield return new WaitForSeconds(.1f);
    }
}
