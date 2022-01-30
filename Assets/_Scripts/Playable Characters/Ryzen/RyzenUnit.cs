using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenUnit : PlayableUnit
{
    [Header("Animation")]
    [SerializeField] [Range(0.5f, 1f)] protected float _hitAnimationTime = 0.25f;

    [Header("Knockback")]
    [SerializeField] [Range(0.1f, 200f)] protected float _defaultKnockBackForce = 0.25f;

    protected Ryzen _ryzen;
    protected float _currentKnockBackForce = 0f;
    protected GameObject _currentAggressor = null;

    protected override void Awake()
    {
        base.Awake();
        this._ryzen = GetComponent<Ryzen>();
    }

    protected void FixedUpdate()
    {
        if (this._takingHit)
        {
            float sign = Mathf.Sign(this.transform.position.x - this._currentAggressor.transform.position.x);
            if (sign >= 0)
            {
                this._ryzen.core.rgbd.AddForce(Vector2.right * this._currentKnockBackForce);

            }
            else
            {

                this._ryzen.core.rgbd.AddForce(Vector2.left * this._currentKnockBackForce);
            }
        }
    }

    public override void TakeDamage(float amount, GameObject aggressor, float? knockBackForce)
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
        // Dies
    }

    public void TakeHit(GameObject aggressor)
    {
        this._takingHit = true;
        this._currentAggressor = aggressor;
        // Trigger hit state
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
        this._ryzen.SetVelocityX(0f);
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