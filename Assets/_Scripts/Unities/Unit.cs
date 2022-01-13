using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Needed Objects
    [Header("Needed Objects")]
    [SerializeField] GameObject _body;

    // Unit Health 
    [Header("Unit Health")]
    [SerializeField] [Range(10f, 5000f)] protected float _totalHP = 80f;

    [Header("Invulnerability")]
    [SerializeField] [Range(0.5f, 10f)] protected float _invulnerabilityTimer = 1.5f;
    [SerializeField] [Range(0.1f, 1f)] protected float _invunerabillityMiniDuration = 0.1f;
    [SerializeField] [Range(0.1f, 5f)] protected float _invunerabillityTotalDuration = 1.5f;

    // Needed Components
    protected SpriteRenderer _spriteRenderer;

    // Config non parameter
    protected float _currentHP;
    protected bool _invunerable = false;
    protected bool _takingHit = false;

    // Logic stuff 
    public bool dead => this._currentHP <= 0;
    public bool takingHit => this._takingHit;
    public bool invunerable => this._invunerable;
    protected float _invunerabillityTotalTimer = 0.0f;

    // MonoBehaviour Cycle
    protected virtual void Awake()
    {
        this._spriteRenderer = this._body.GetComponent<SpriteRenderer>();
    }

    protected virtual void Start()
    {
        this._currentHP = this._totalHP;
    }

    protected virtual void Update()
    {
        if (this._invunerable)
        {
            this.InvunerabilityEffect();
        }
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


    private void InvunerabilityEffect()
    {
        this._invunerabillityTotalTimer += Time.deltaTime;

        if (this._invunerabillityTotalTimer >= this._invunerabillityTotalDuration)
        {
            this._invunerable = false;
            this._invunerabillityTotalTimer = 0.0f;
            this._spriteRenderer.enabled = true;
            return;
        }

        this._invulnerabilityTimer += Time.deltaTime;
        if (this._invulnerabilityTimer >= this._invunerabillityMiniDuration)
        {
            this._invulnerabilityTimer = 0.0f;
            if (this._spriteRenderer.enabled)
            {
                this._spriteRenderer.enabled = false;
            }
            else
            {
                this._spriteRenderer.enabled = true;
            }
        }
    }

}
