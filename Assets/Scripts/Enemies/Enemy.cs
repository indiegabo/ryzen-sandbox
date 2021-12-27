using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    [Header("Config")]
    [SerializeField] [Range(40f, 10000f)] protected float _totalHP = 100f; // Read HP as Health Points

    // Need Components
    protected IStateManager _stateManager;

    // Combat Logic
    protected float _currentHP;

    private void Awake()
    {
        this._stateManager = GetComponent<IStateManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        this._currentHP = this._totalHP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float amount)
    {
        this._currentHP -= amount;
        if (this._currentHP <= 0)
        {
            // Die
            this.Die();
        }
        else
        {
            // Take hit
            this.TakeHit();
        }

        Debug.Log(this._currentHP);
    }

    private void TakeHit()
    {
        this._stateManager.ChangeState("Hit");
        Invoke("EnterIdleState", 0.625f);

    }
    private void Die()
    {
        this._stateManager.ChangeState("Die");
        GetComponent<Collider2D>().enabled = false;
    }

    private void EnterIdleState()
    {
        this._stateManager.ChangeState("Idle");
    }

}
