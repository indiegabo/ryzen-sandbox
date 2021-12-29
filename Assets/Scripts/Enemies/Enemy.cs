using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    [Header("Config")]
    [SerializeField] [Range(40f, 10000f)] protected float _totalHP = 100f; // Read HP as Health Points
    [SerializeField] [Range(1f, 50f)] protected float _defaultSpeed = 2f;
    [SerializeField] [Range(0.5f, 20f)] protected float _eyeSightRange = 5f;
    [SerializeField] protected bool _facingLeft = false;

    [Header("Needed objects")]
    [SerializeField] protected Transform _eyeSight;

    // Non param Needed objects
    Transform _player;

    // Needed Components
    protected IStateManager _stateManager;
    protected Rigidbody2D _rb;

    // Combat Logic
    protected float _currentHP;

    // Flags
    protected bool _takingHit = false;
    protected bool _dead = false;

    protected void Awake()
    {
        this._stateManager = GetComponent<IStateManager>();
        this._rb = GetComponent<Rigidbody2D>();
        this._player = FindObjectOfType<PlayableCharacter>().gameObject.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        this._currentHP = this._totalHP;
    }

    // Update is called once per frame
    protected void Update()
    {
        this.FaceEnemy();
        this.HandleState();
    }

    protected void FixedUpdate()
    {
        this.HandleWalk();
    }

    // Handling Stuff
    protected void HandleWalk()
    {
        if (this.CanWalk() && this.CanSeePlayer())
        {
            float distanceSign = Mathf.Sign(this._player.position.x - this.transform.position.x);
            this._rb.velocity = (Vector2.right * this._defaultSpeed) * distanceSign;
        }
        else
        {
            this._rb.velocity = new Vector2(0, 0);
        }
    }

    protected void HandleState()
    {
        if (Mathf.Abs(this._rb.velocity.x) > 0)
            this._stateManager.ChangeState("Walk");
        else if (!this._takingHit && !this._dead)
            this._stateManager.ChangeState("Idle");
        else if (this._takingHit)
            this._stateManager.ChangeState("Hit");
        else if (this._dead)
            this._stateManager.ChangeState("Die");
    }

    protected void FaceEnemy()
    {
        if (this._rb.velocity.x > 0 && this._facingLeft || this._rb.velocity.x < 0 && !this._facingLeft)
        {
            this._facingLeft = !this._facingLeft;
            transform.Rotate(0f, -180f, 0f);
        }
    }

    // Actions
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
    }
    protected void TakeHit()
    {
        this._takingHit = true;
        Invoke("DoneTakingHit", 0.625f);

    }
    protected void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        this._dead = true;
    }

    protected void DoneTakingHit()
    {
        this._takingHit = false;
    }

    // Checks
    protected bool CanWalk()
    {
        return !this._takingHit && !this._dead;
    }

    protected bool CanSeePlayer()
    {
        Vector2 endPos = this.CalculateSighEndPosition();

        RaycastHit2D hit = Physics2D.Linecast(this._eyeSight.position, endPos, 1 << LayerMask.NameToLayer("Player"));
        return hit.collider != null;
    }

    protected Vector2 CalculateSighEndPosition()
    {
        Vector2 endPos;

        if (this._facingLeft)
        {
            endPos = this._eyeSight.position + Vector3.left * this._eyeSightRange;

        }
        else
        {
            endPos = this._eyeSight.position + Vector3.right * this._eyeSightRange;

        }

        return endPos;
    }

    // Debug stuff
    public void OnDrawGizmosSelected()
    {
        if (this._eyeSight == null)
            return;

        Vector2 endPos = this.CalculateSighEndPosition();
        Gizmos.DrawLine(this._eyeSight.position, endPos);
    }
}
